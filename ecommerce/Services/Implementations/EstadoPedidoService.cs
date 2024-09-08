using ecommerce.Model;
using ecommerce.Repository.Interfaces;
using ecommerce.Services.Interfaces;

namespace ecommerce.Services.Implementations
{
    public class EstadoPedidoService : IEstadoPedidoService
    {
        private readonly IEstadoPedidoRepository _estadoPedidoRepository;
        public EstadoPedidoService(IEstadoPedidoRepository estadoPedidoRepository)
        {
            _estadoPedidoRepository = estadoPedidoRepository;
        }

        public async Task<IEnumerable<TbEstadoPedido>> GetAllAsync()
        {
            return await _estadoPedidoRepository.GetAllAsync();
        }

        public async Task<TbEstadoPedido> GetByIdAsync(int id)
        {
            return await _estadoPedidoRepository.GetByIdAsync(id);
        }
    }
}
