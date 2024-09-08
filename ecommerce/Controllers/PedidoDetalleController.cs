using ecommerce.Model;
using ecommerce.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoDetalleController : Controller
    {
        private readonly IPedidoDetalleService _pedidoDetalleService;
        public PedidoDetalleController(IPedidoDetalleService pedidoDetalleService)
        {
            _pedidoDetalleService = pedidoDetalleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pedidoDetalles = await _pedidoDetalleService.GetAllProductosAsync();
            return Ok(pedidoDetalles);
        }

        [HttpGet("{pedidoId}/{productoId}")]
        public async Task<IActionResult> GetById(int pedidoId, int productoId)
        {
            var pedidoDetalle = await _pedidoDetalleService.GetByPedidoIdProductoIdAsync(pedidoId, productoId);
            if (pedidoDetalle == null)
                return NotFound();

            return Ok(pedidoDetalle);
        }

        

    }
}
