using ecommerce.Model;
using ecommerce.Services.Implementations;
using ecommerce.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.Controllers
{
    [ApiController] 
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpGet("{email}/{password}")]
        public async Task<IActionResult> GetTokenLogin(string email, string password)
        {
            var token = await _loginService.ValidateUserAndGenerateTokenAsync(email, password);
            if (token == null)
                return NotFound();

            return Ok(new { Token = token });
        }

        [HttpGet("decode/{token}")]
        public IActionResult DecodeToken(string token)
        {
            var decodedToken = _loginService.DecodeToken(token);
            if (string.IsNullOrEmpty(decodedToken))
                return BadRequest("Invalid token");

            return Ok(new { DecodedToken = decodedToken });
        }
    }
}
