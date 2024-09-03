using ecommerce.Model;

namespace ecommerce.Services.Interfaces
{
    public interface ILoginService
    {
        Task<TokenResponse> ValidateUserAndGenerateTokenAsync(string correo, string clave);

        string DecodeToken(string token);
    }
}
