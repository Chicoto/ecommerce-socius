using ecommerce.Model;

namespace ecommerce.Services.Interfaces
{
    public interface IPedidoService
    {
        Task<IEnumerable<TbPedido>> GetAllPedidosAsync();
        Task<IEnumerable<TbPedido>> GetPedidosByUsuarioTokenAsync(Guid token);
        Task<int> InsertPedidoAsync(TbPedido pedido);
        Task<TbPedido?> GetByIdAsync(int pedidoId);
    }
}
