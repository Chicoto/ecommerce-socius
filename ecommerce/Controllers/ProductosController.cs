using ecommerce.Model;
using ecommerce.Services.Implementations;
using ecommerce.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : Controller
    {
        private readonly IProductoService _productoService;

        public ProductosController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbProducto>>> GetAll()
        {
            var productos = await _productoService.GetAllProductosAsync();
            return Ok(productos);
        }

        [HttpGet ("habilitados")]
        public async Task<ActionResult<IEnumerable<TbProducto>>> GetAllHabilitados()
        {
            var productos = await _productoService.GetAllProductosHabilitadosAsync();
            return Ok(productos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TbProducto>> GetById(int id)
        {
            var producto = await _productoService.GetByIdAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            return Ok(producto);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TbProducto producto)
        {
            if (producto == null)
                return BadRequest();

            var productoId = await _productoService.InsertProductoAsync(producto);

            if (productoId == 0)  
                return StatusCode(500, "Error al crear el producto.");

            // Retornar el ID con un 201 Created y la URL para obtener el usuario creado
            return CreatedAtAction(nameof(GetById), new { id = productoId }, new { ProductoId = productoId });
        }

        [HttpPut("update/enabled/{id}/{enabled}")]
        public async Task<IActionResult> UpdateHabilitado(int id, bool enabled)
        {
            var existingUsuario = await _productoService.GetByIdAsync(id);
            if (existingUsuario == null)
                return NotFound();

            var updateResult = await _productoService.UpdateHabilitaProductoAsync(id, enabled);

            if (updateResult == 1)
            {
                return NoContent();
            }
            else
            {
                return StatusCode(500, "Error al actualizar el producto.");
            }
        }

        [HttpPut("update/deleted/{id}/{deleted}")]
        public async Task<IActionResult> UpdateEliminado(int id, bool deleted)
        {
            var existingUsuario = await _productoService.GetByIdAsync(id);
            if (existingUsuario == null)
                return NotFound();

            var updateResult = await _productoService.UpdateEliminaProductoAsync(id, deleted);

            if (updateResult == 1)
            {
                return NoContent();
            }
            else
            {
                return StatusCode(500, "Error al actualizar el producto.");
            }
        }

        [HttpPut("update/stock/{id}/{stock}")]
        public async Task<IActionResult> UpdateStock(int id, int stock)
        {
            var existingUsuario = await _productoService.GetByIdAsync(id);
            if (existingUsuario == null)
                return NotFound();

            var updateResult = await _productoService.UpdateStockProductoAsync(id, stock);

            if (updateResult == 1)
            {
                return NoContent();
            }
            else
            {
                return StatusCode(500, "Error al actualizar el producto.");
            }
        }

        [HttpPut("update/details/{id}/{name}/{description}/{price}")]
        public async Task<IActionResult> UpdateStock(int id, string name, string description, decimal price)
        {
            var existingUsuario = await _productoService.GetByIdAsync(id);
            if (existingUsuario == null)
                return NotFound();

            var updateResult = await _productoService.UpdateProductoDetailsAsync(id, name, description, price);

            if (updateResult == 1)
            {
                return NoContent();
            }
            else
            {
                return StatusCode(500, "Error al actualizar el producto.");
            }
        }
    }
}
