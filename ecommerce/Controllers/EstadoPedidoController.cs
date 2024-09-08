using ecommerce.Model;
using ecommerce.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstadoPedidoController : Controller
    {
        private readonly IEstadoPedidoService _estadoPedidoService;

        public EstadoPedidoController(IEstadoPedidoService estadoPedidoService)
        {
            _estadoPedidoService = estadoPedidoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var estadosPedido = await _estadoPedidoService.GetAllAsync();
            return Ok(estadosPedido);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var estadoPedido = await _estadoPedidoService.GetByIdAsync(id);
            if (estadoPedido == null)
                return NotFound();

            return Ok(estadoPedido);
        }

        
    }
}
