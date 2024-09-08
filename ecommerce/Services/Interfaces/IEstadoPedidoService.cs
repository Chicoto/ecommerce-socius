using ecommerce.Model;

namespace ecommerce.Services.Interfaces
{
    public interface IEstadoPedidoService
    {
        Task<IEnumerable<TbEstadoPedido>> GetAllAsync();
        Task<TbEstadoPedido> GetByIdAsync(int id);
    }
}
