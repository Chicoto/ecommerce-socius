using ecommerce.Model;

namespace ecommerce.Services.Interfaces
{
    public interface IPedidoDetalleService
    {
        Task<IEnumerable<TbPedidoDetalle>> GetAllProductosAsync();
        Task<TbPedidoDetalle> GetByPedidoIdProductoIdAsync(int pedidoId, int productoId);
    }
}
