using ecommerce.Model;

namespace ecommerce.Repository.Interfaces
{
    public interface IUsuarioTokenRepository
    {
        //Task<IEnumerable<TbUsuarioToken>> GetAllAsync();
        Task<TbUsuarioToken> GetByIdAsync(int usuarioId);
        //Task<int> InsertAsync(TbUsuarioToken usuarioToken);
        //Task<int> UpdateAsync(TbUsuarioToken usuarioToken);
        //Task<int> DeleteAsync(int usuarioId);
    }
}
