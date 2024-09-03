using ecommerce.Model;

namespace ecommerce.Repository.Interfaces
{
    public interface ILoginRepository
    {
        Task<string> ValidateUserAndGenerateTokenAsync(string correo, string clave);
    }
}
