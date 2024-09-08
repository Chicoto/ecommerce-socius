using ecommerce.Model;
using ecommerce.Repository.Implementations;
using ecommerce.Repository.Interfaces;
using ecommerce.Services.Interfaces;

namespace ecommerce.Services.Implementations
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoService(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public async Task<IEnumerable<TbPedido>> GetAllPedidosAsync()
        {
            return await _pedidoRepository.GetAllPedidosAsync();
        }

        public async Task<IEnumerable<TbPedido>> GetPedidosByUsuarioTokenAsync(Guid token)
        {
            return await _pedidoRepository.GetPedidosByUsuarioTokenAsync(token);
        }

        public async Task<TbPedido?> GetByIdAsync(int id)
        {
            return await _pedidoRepository.GetByIdAsync(id);
        }

        public async Task<int> InsertPedidoAsync(TbPedido pedido)
        {
            return await _pedidoRepository.InsertPedidoAsync(pedido);
        }

        
    }
}
