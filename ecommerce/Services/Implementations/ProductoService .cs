using ecommerce.Model;
using ecommerce.Repository.Interfaces;
using ecommerce.Services.Interfaces;

namespace ecommerce.Services.Implementations
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _productoRepository;

        public ProductoService(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public async Task<IEnumerable<TbProducto>> GetAllProductosAsync()
        {
            return await _productoRepository.GetAllProductosAsync();
        }

        public async Task<IEnumerable<TbProducto>> GetAllProductosHabilitadosAsync()
        {
            var productos = await GetAllProductosAsync();
            var productosHabilitados = productos.Where(p => p.Habilitado).ToList();
            return productosHabilitados;
        }

        public async Task<TbProducto?> GetByIdAsync(int id)
        {
            return await _productoRepository.GetByIdAsync(id);
        }

        public async Task<int> InsertProductoAsync(TbProducto producto)
        {
            return await _productoRepository.InsertProductoAsync(producto);
        }

        public async Task<int> UpdateEliminaProductoAsync(int productoId, bool eliminado)
        {
            return await _productoRepository.UpdateEliminaProductoAsync(productoId, eliminado);
        }

        public async Task<int> UpdateHabilitaProductoAsync(int productoId, bool habilitado)
        {
            return await _productoRepository.UpdateHabilitaProductoAsync(productoId, habilitado);
        }

        public async Task<int> UpdateProductoDetailsAsync(int productoId, string nombre, string descripcion, decimal precio)
        {
            return await _productoRepository.UpdateProductoDetailsAsync(productoId, nombre, descripcion, precio);
        }

        public async Task<int> UpdateStockProductoAsync(int productoId, int stock)
        {
            return await _productoRepository.UpdateStockProductoAsync(productoId, stock);
        }
    }
}