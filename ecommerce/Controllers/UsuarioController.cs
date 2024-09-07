using ecommerce.Model;
using ecommerce.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.Controllers
{
    [ApiController] 
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var usuarios = await _usuarioService.GetAllUsuariosAsync();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var usuario = await _usuarioService.GetByIdAsync(id);
            if (usuario == null)
                return NotFound();

            return Ok(usuario);
        }

        [HttpGet("{email}/{password}")]
        public async Task<IActionResult> GetByCorreoClave(string email, string password)
        {
            var usuario = await _usuarioService.GetUsuarioByCorreoClaveAsync(email, password);
            if (usuario == null)
                return NotFound();

            return Ok(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TbUsuario usuario)
        {
            if (usuario == null)
                return BadRequest();

            // Insertar el usuario y obtener el ID generado
            var usuarioId = await _usuarioService.InsertUsuarioAsync(usuario);

            if (usuarioId == 0)  // Puedes cambiar esto para otra verificación de error si es necesario
                return StatusCode(500, "Error al crear el usuario.");

            // Retornar el ID con un 201 Created y la URL para obtener el usuario creado
            return CreatedAtAction(nameof(GetById), new { id = usuarioId }, new { UsuarioId = usuarioId });

        }

        [HttpPut("update/name/{id}/{name}")]
        public async Task<IActionResult> UpdateNombre(int id, string name)
        {

            var existingUsuario = await _usuarioService.GetByIdAsync(id);
            if (existingUsuario == null)
                return NotFound();

            // Intentar actualizar el nombre del usuario
            var updateResult = await _usuarioService.UpdateNombreUsuarioAsync(id, name);

            // Verificar si la actualización fue exitosa
            if (updateResult == 1)
            {
                // Si fue exitosa, devolver un 204 No Content
                return NoContent();
            }
            else
            {
                // Si hubo un error al actualizar, devolver un 500 Internal Server Error
                return StatusCode(500, "Error al actualizar el usuario.");
            }
        }

        [HttpPut("update/password/{id}/{password}")]
        public async Task<IActionResult> UpdateClave(int id, string password)
        {

            var existingUsuario = await _usuarioService.GetByIdAsync(id);
            if (existingUsuario == null)
                return NotFound();

            // Intentar actualizar el nombre del usuario
            var updateResult = await _usuarioService.UpdateClaveUsuarioAsync(id, password);

            // Verificar si la actualización fue exitosa
            if (updateResult == 1)
            {
                // Si fue exitosa, devolver un 204 No Content
                return NoContent();
            }
            else
            {
                // Si hubo un error al actualizar, devolver un 500 Internal Server Error
                return StatusCode(500, "Error al actualizar el usuario.");
            }
        }

        [HttpPut("update/enabled/{id}/{enabled}")]
        public async Task<IActionResult> UpdateHabilitado(int id, bool enabled)
        {

            var existingUsuario = await _usuarioService.GetByIdAsync(id);
            if (existingUsuario == null)
                return NotFound();

            // Intentar actualizar el nombre del usuario
            var updateResult = await _usuarioService.UpdateHabilitaUsuarioAsync(id, enabled);

            // Verificar si la actualización fue exitosa
            if (updateResult == 1)
            {
                // Si fue exitosa, devolver un 204 No Content
                return NoContent();
            }
            else
            {
                // Si hubo un error al actualizar, devolver un 500 Internal Server Error
                return StatusCode(500, "Error al actualizar el usuario.");
            }
        }

        [HttpPut("update/deleted/{id}/{deleted}")]
        public async Task<IActionResult> UpdateEliminado(int id, bool deleted) 
        {

            var existingUsuario = await _usuarioService.GetByIdAsync(id);
            if (existingUsuario == null)
                return NotFound();

            // Intentar actualizar el nombre del usuario
            var updateResult = await _usuarioService.UpdateEliminaUsuarioAsync(id, deleted);

            // Verificar si la actualización fue exitosa
            if (updateResult == 1)
            {
                // Si fue exitosa, devolver un 204 No Content
                return NoContent();
            }
            else
            {
                // Si hubo un error al actualizar, devolver un 500 Internal Server Error
                return StatusCode(500, "Error al actualizar el usuario.");
            }
        }

    }
}
