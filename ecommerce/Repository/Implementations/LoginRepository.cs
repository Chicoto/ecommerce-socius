using Dapper;
using ecommerce.Data;
using ecommerce.Model;
using ecommerce.Repository.Interfaces;
using System.Data;
using System.Linq;


namespace ecommerce.Repository.Implementations
{
    public class LoginRepository : ILoginRepository
    {
        private readonly DapperContext _context;

        public LoginRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<string> ValidateUserAndGenerateTokenAsync(string correo, string clave)
        {
            var storedProcedure = "SP_ValidateUserAndGenerateToken";
            using (var connection = _context.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("Correo", correo);
                parameters.Add("Clave", clave);
                parameters.Add("Token", dbType: DbType.Guid, direction: ParameterDirection.Output);

                // Ejecuta el procedimiento almacenado
                await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);

                // Obtiene el token generado
                var token = parameters.Get<Guid?>("Token");

                return token.ToString();
            }
        }


    }
}
