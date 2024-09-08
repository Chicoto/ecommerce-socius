using Dapper;
using ecommerce.Data;
using ecommerce.Model;
using ecommerce.Repository.Interfaces;
using System.Data;
using System.Linq;
using System.Net.WebSockets;

namespace ecommerce.Repository.Implementations
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DapperContext _context;

        public UsuarioRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TbUsuario>> GetAllUsuariosAsync()
        {
            var storedProcedure = "SP_GetAllUsuarios";
            using (var connection = _context.CreateConnection())
            {
                var parameters = new DynamicParameters();

                return await connection.QueryAsync<TbUsuario>(storedProcedure, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<TbUsuario?> GetByIdAsync(int usuarioId)
        {
            var storedProcedure = "SP_GetUsuarioById";
            using (var connection = _context.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("UsuarioId", usuarioId);

                return await connection.QuerySingleOrDefaultAsync<TbUsuario?>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<TbUsuario?> GetUsuarioByCorreoClaveAsync(string correo, string clave)
        {
            var storedProcedure = "SP_GetUsuarioByCorreoClave";
            using (var connection = _context.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("Correo", correo);
                parameters.Add("Clave", clave);

                // Usa QuerySingleOrDefaultAsync para obtener un solo registro
                return await connection.QuerySingleOrDefaultAsync<TbUsuario?>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<int> InsertUsuarioAsync(TbUsuario usuario)
        {
            var storedProcedure = "SP_InsertUsuario";
            using (var connection = _context.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("Nombre", usuario.Nombre);
                parameters.Add("Clave", usuario.Clave);
                parameters.Add("Correo", usuario.Correo);
                parameters.Add("EsAdmin", usuario.EsAdmin);
                parameters.Add("Eliminado", usuario.Eliminado);
                parameters.Add("Habilitado", usuario.Habilitado);

                // Usa QuerySingleOrDefaultAsync para obtener un solo registro
                return await connection.QuerySingleOrDefaultAsync<int>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<int> UpdateHabilitaUsuarioAsync(int usuarioId, bool habilitado)
        {
            var storedProcedure = "SP_UpdateUsuarioHabilitado";
            using (var connection = _context.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("UsuarioId", usuarioId);
                parameters.Add("Habilitado", habilitado);

                // Usa QuerySingleOrDefaultAsync para obtener un solo registro
                return await connection.QuerySingleOrDefaultAsync<int>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<int> UpdateEliminaUsuarioAsync(int usuarioId, bool eliminado)
        {
            var storedProcedure = "SP_UpdateUsuarioEliminado";
            using (var connection = _context.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("UsuarioId", usuarioId);
                parameters.Add("Eliminado", eliminado);

                // Usa QuerySingleOrDefaultAsync para obtener un solo registro
                var result  =  await connection.QuerySingleOrDefaultAsync<int>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<int> UpdateClaveUsuarioAsync(int usuarioId, string clave)
        {
            var storedProcedure = "SP_UpdateUsuarioClave";
            using (var connection = _context.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("UsuarioId", usuarioId);
                parameters.Add("Clave", clave);

                // Usa QuerySingleOrDefaultAsync para obtener un solo registro
                return await connection.QuerySingleOrDefaultAsync<int>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<int> UpdateNombreUsuarioAsync(int usuarioId, string nombre)
        {
            var storedProcedure = "SP_UpdateUsuarioNombre";
            using (var connection = _context.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("UsuarioId", usuarioId);
                parameters.Add("Nombre", nombre);

                // Usa QuerySingleOrDefaultAsync para obtener un solo registro
                return await connection.QuerySingleOrDefaultAsync<int>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
        }

    }
}
