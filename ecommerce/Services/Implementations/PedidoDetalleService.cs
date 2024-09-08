using ecommerce.Model;
using ecommerce.Repository.Interfaces;
using ecommerce.Services.Interfaces;

namespace ecommerce.Services.Implementations
{
    public class PedidoDetalleService : IPedidoDetalleService
    {
        private readonly IPedidoDetalleRepository _pedidoDetalleRepository;

        public PedidoDetalleService(IPedidoDetalleRepository pedidoDetalleRepository)
        {
            _pedidoDetalleRepository = pedidoDetalleRepository;
        }

        public async Task<IEnumerable<TbPedidoDetalle>> GetAllProductosAsync()
        {
            return await _pedidoDetalleRepository.GetAllProductosAsync();
        }

        public async Task<TbPedidoDetalle> GetByPedidoIdProductoIdAsync(int pedidoId, int productoId)
        {
            return await _pedidoDetalleRepository.GetByPedidoIdProductoIdAsync(pedidoId, productoId);
        }
    }
}
