using Dapper;
using ecommerce.Data;
using ecommerce.Model;
using ecommerce.Repository.Interfaces;
using Newtonsoft.Json.Linq;
using System.Data;

namespace ecommerce.Repository.Implementations
{
    public class PedidoDetalleRepository : IPedidoDetalleRepository
    {
        private readonly DapperContext _context;

        public PedidoDetalleRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TbPedidoDetalle>> GetAllProductosAsync()
        {
            var storedProcedure = "SP_GetAllPedidosDetalle";
            using (var connection = _context.CreateConnection())
            {
                var parameters = new DynamicParameters();

                return await connection.QueryAsync<TbPedidoDetalle>(storedProcedure, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<TbPedidoDetalle> GetByPedidoIdProductoIdAsync(int pedidoId, int productoId)
        {
            var storedProcedure = "SP_GetPedidosByToken";
            using (var connection = _context.CreateConnection())
            {
                // Crear los parámetros para el procedimiento almacenado
                var parameters = new DynamicParameters();
                parameters.Add("PedidoId", pedidoId);
                parameters.Add("ProductoId", productoId);

                // Ejecutar el procedimiento almacenado y mapear el resultado a la clase TbPedido
                var detalle = await connection.QuerySingleOrDefaultAsync<TbPedidoDetalle>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);

                return detalle;
            }
        }
    }
}
