using ecommerce.Model;

namespace ecommerce.Repository.Interfaces
{
    public interface IPedidoDetalleRepository
    {
        Task<IEnumerable<TbPedidoDetalle>> GetAllProductosAsync();
        Task<TbPedidoDetalle> GetByPedidoIdProductoIdAsync(int pedidoId, int productoId);
    }

}
