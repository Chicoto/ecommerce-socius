using ecommerce.Model;
using ecommerce.Services.Implementations;
using ecommerce.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : Controller
    {
        private readonly IPedidoService _pedidoService;
        public PedidoController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pedidos = await _pedidoService.GetAllPedidosAsync();
            return Ok(pedidos);
        }

        [HttpGet("{token}")]
        public async Task<IActionResult> GetAllByToken(Guid token)
        {
            var pedidos = await _pedidoService.GetPedidosByUsuarioTokenAsync(token);
            if (pedidos == null)
                return NotFound();

            return Ok(pedidos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var pedido = await _pedidoService.GetByIdAsync(id);
            if (pedido == null)
                return NotFound();

            return Ok(pedido);
        }


        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TbPedido pedido)
        {
            if (pedido == null)
                return BadRequest();

            var pedidoId = await _pedidoService.InsertPedidoAsync(pedido);

            if (pedidoId == 0)
                return StatusCode(500, "Error al crear el pedido.");

            // Retornar el ID con un 201 Created y la URL para obtener el usuario creado
            return CreatedAtAction(nameof(GetById), new { id = pedidoId }, new { PedidoId = pedidoId });
        }

    }
}
