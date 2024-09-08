using Dapper;
using ecommerce.Data;
using ecommerce.Model;
using ecommerce.Repository.Interfaces;
using System.Data;

namespace ecommerce.Repository.Implementations
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly DapperContext _context;

        public ProductoRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TbProducto>> GetAllProductosAsync()
        {
            var storedProcedure = "SP_GetAllProductos";
            using (var connection = _context.CreateConnection())
            {
                var parameters = new DynamicParameters();

                return await connection.QueryAsync<TbProducto>(storedProcedure, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<TbProducto?> GetByIdAsync(int id)
        {
            var storedProcedure = "SP_GetProductoById";
            using (var connection = _context.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("ProductoId", id);

                return await connection.QuerySingleOrDefaultAsync<TbProducto?>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<int> InsertProductoAsync(TbProducto producto)
        {
            var storedProcedure = "SP_InsertProducto";
            using (var connection = _context.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Nombre", producto.Nombre);
                parameters.Add("@Descripcion", producto.Descripcion);
                parameters.Add("@Stock", producto.Stock);
                parameters.Add("@Precio", producto.Precio);
                parameters.Add("@Habilitado", producto.Habilitado);
                parameters.Add("@Eliminado", producto.Eliminado);

                return await connection.QuerySingleOrDefaultAsync<int>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<int> UpdateHabilitaProductoAsync(int productoId, bool habilitado)
        {
            var storedProcedure = "SP_UpdateProductoHabilitado";
            using (var connection = _context.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("ProductoId", productoId);
                parameters.Add("Habilitado", habilitado);

                return await connection.QuerySingleOrDefaultAsync<int>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<int> UpdateEliminaProductoAsync(int productoId, bool eliminado)
        {
            var storedProcedure = "SP_UpdateProductoEliminado";
            using (var connection = _context.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("ProductoId", productoId);
                parameters.Add("Eliminado", eliminado);

                return await connection.QuerySingleOrDefaultAsync<int>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<int> UpdateStockProductoAsync(int productoId, int stock)
        {
            var storedProcedure = "SP_UpdateProductoStock";
            using (var connection = _context.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("ProductoId", productoId);
                parameters.Add("Stock", stock);

                return await connection.QuerySingleOrDefaultAsync<int>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<int> UpdateProductoDetailsAsync(int productoId, string nombre, string descripcion, decimal precio)
        {
            var storedProcedure = "SP_UpdateProductoDetails";
            using (var connection = _context.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("ProductoId", productoId);
                parameters.Add("Nombre", nombre);
                parameters.Add("Descripcion", descripcion);
                parameters.Add("Precio", precio);

                return await connection.QuerySingleOrDefaultAsync<int>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
        }



    }
}
