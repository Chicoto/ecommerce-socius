using ecommerce.Model;

namespace ecommerce.Repository.Interfaces
{
    public interface IEstadoPedidoRepository
    {
        Task<IEnumerable<TbEstadoPedido>> GetAllAsync();
        Task<TbEstadoPedido> GetByIdAsync(int id);
    }
}
