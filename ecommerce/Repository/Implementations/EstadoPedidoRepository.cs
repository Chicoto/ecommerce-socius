using Dapper;
using ecommerce.Data;
using ecommerce.Model;
using ecommerce.Repository.Interfaces;
using System.Data;

namespace ecommerce.Repository.Implementations
{
    public class EstadoPedidoRepository : IEstadoPedidoRepository
    {
        private readonly DapperContext _context;

        public EstadoPedidoRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TbEstadoPedido>> GetAllAsync()
        {
            var storedProcedure = "SP_GetAllEstadoPedido";
            using (var connection = _context.CreateConnection())
            {
                var parameters = new DynamicParameters();

                return await connection.QueryAsync<TbEstadoPedido>(storedProcedure, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<TbEstadoPedido> GetByIdAsync(int id)
        {
            var storedProcedure = "SP_GetEstadoPedidoById";
            using (var connection = _context.CreateConnection())
            {
                // Crear los parámetros para el procedimiento almacenado
                var parameters = new DynamicParameters();
                parameters.Add("EstadoId", id);

                // Ejecutar el procedimiento almacenado y mapear el resultado a la clase TbPedido
                var estado = await connection.QuerySingleOrDefaultAsync<TbEstadoPedido>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);

                return estado;
            }
        }
    }
}

