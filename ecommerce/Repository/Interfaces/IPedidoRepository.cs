using ecommerce.Model;

namespace ecommerce.Repository.Interfaces
{
    public interface IPedidoRepository
    {
        Task<IEnumerable<TbPedido>> GetAllPedidosAsync();
        Task<IEnumerable<TbPedido>> GetPedidosByUsuarioTokenAsync(Guid token);
        Task<int> InsertPedidoAsync(TbPedido pedido);
        Task<TbPedido?> GetByIdAsync(int pedidoId);

    }
}
