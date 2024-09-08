using Dapper;
using ecommerce.Data;
using ecommerce.Helpers;
using ecommerce.Model;
using ecommerce.Repository.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ecommerce.Repository.Implementations
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly DapperContext _context;

        public PedidoRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TbPedido>> GetAllPedidosAsync()
        {
            var storedProcedure = "SP_GetAllPedidos";
            using (var connection = _context.CreateConnection())
            {
                var parameters = new DynamicParameters();

                return await connection.QueryAsync<TbPedido>(storedProcedure, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<TbPedido>> GetPedidosByUsuarioTokenAsync(Guid token)
        {
            var storedProcedure = "SP_GetPedidosByToken";
            using (var connection = _context.CreateConnection())
            {
                // Crear los parámetros para el procedimiento almacenado
                var parameters = new DynamicParameters();
                parameters.Add("Token", token, DbType.Guid);

                // Ejecutar el procedimiento almacenado y mapear el resultado a la clase TbPedido
                var pedidos = await connection.QueryAsync<TbPedido>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);

                return pedidos;
            }
        }

        public async Task<int> InsertPedidoAsync(TbPedido pedido)
        {
            var parameters = new DynamicParameters();

            // Agregar los parámetros para la cabecera del pedido
            parameters.Add("Token", pedido.Token, DbType.Guid);
            parameters.Add("EstadoId", pedido.EstadoId, DbType.Int32);
            parameters.Add("ValorTotal", pedido.ValorTotal, DbType.Decimal);
            parameters.Add("Fecha", pedido.Fecha, DbType.Date);
            parameters.Add("Eliminado", pedido.Eliminado, DbType.Boolean);

            // Crear un DataTable para los detalles del pedido
            var detalleTable = PedidoHelper.CreatePedidoDetalleDataTable(pedido.Detalles);

            // Agregar el parámetro de tipo tabla para los detalles
            var detallesParameter = new SqlParameter
            {
                ParameterName = "Detalles",
                SqlDbType = SqlDbType.Structured,
                TypeName = "dbo.PedidoDetalleType", // Tipo de tabla definido en la base de datos
                Value = detalleTable
            };

            // Agregar parámetro de salida
            parameters.Add("Resultado", dbType: DbType.Int32, direction: ParameterDirection.Output);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync("SP_InsertPedido", new { parameters, detallesParameter }, commandType: CommandType.StoredProcedure);

                // Obtener el valor del parámetro de salida
                int resultado = parameters.Get<int>("Resultado");

                return resultado; // Retornar el resultado (1 = éxito, 0 = error)
            }
        }

        public async Task<TbPedido?> GetByIdAsync(int pedidoId)
        {
            var storedProcedure = "SP_GetPedidoById";
            using (var connection = _context.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("PedidoId", pedidoId);

                return await connection.QuerySingleOrDefaultAsync<TbPedido?>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
        }


    }
}
