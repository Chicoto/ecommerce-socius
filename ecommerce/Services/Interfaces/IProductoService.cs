using ecommerce.Model;

namespace ecommerce.Services.Interfaces
{
    public interface IProductoService
    {
        Task<IEnumerable<TbProducto>> GetAllProductosAsync();
        Task<IEnumerable<TbProducto>> GetAllProductosHabilitadosAsync();
        Task<TbProducto?> GetByIdAsync(int id);
        Task<int> InsertProductoAsync(TbProducto producto);
        Task<int> UpdateHabilitaProductoAsync(int productoId, bool habilitado);
        Task<int> UpdateEliminaProductoAsync(int productoId, bool eliminado);
        Task<int> UpdateStockProductoAsync(int productoId, int stock);
        Task<int> UpdateProductoDetailsAsync(int productoId, string nombre, string descripcion, decimal precio);
    }
}
