using ecommerce.Model;
using ecommerce.Repository.Implementations;
using ecommerce.Repository.Interfaces;
using ecommerce.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Threading.Tasks;


namespace ecommerce.Services.Implementations
{
    public class LoginService : ILoginService
    {

        private readonly ILoginRepository _loginRepository;
        private readonly string _secretKey; // Clave secreta para firmar el token
        private string _clave = "N2I0ZDU2NzM3YTQ2MGFlYWIwZjM3ZGI4NzNkZjFhZWE5MDMzOTZkMzI5MjY4YTM2YzBkMGFiZTAyMmEyZQ==";

        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
            _secretKey = _clave;
        }

        public async Task<TokenResponse> ValidateUserAndGenerateTokenAsync(string correo, string clave)
        {
            // Lógica para validar el usuario con el correo y la clave
            var token = await _loginRepository.ValidateUserAndGenerateTokenAsync(correo, clave);

            if (token == null || token == "")
            {
                // Usuario no encontrado o credenciales inválidas
                return null;
            }

            // Crear el token JWT
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_clave); // Asegúrate de que _clave es una clave secreta válida
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Hash, token)
                }),
                //Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenSalida = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(tokenSalida);

            // Crear y retornar el objeto TokenResponse con el token incluido
            return new TokenResponse
            {
                Token = tokenString
            };
        }

        public string DecodeToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_clave);
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key)
            };

            try
            {
                var principal = tokenHandler.ValidateToken(token, validationParameters, out var validatedToken);
                var claims = principal.Claims;

                // Extraer valores de las reclamaciones (claims)
                var tokenDetalle = claims.FirstOrDefault(c => c.Type == ClaimTypes.Hash)?.Value;

                // Construir el resultado
                return $"Token: {tokenDetalle}";
            }
            catch
            {
                return "Invalid token";
            }
        }
    }
}
