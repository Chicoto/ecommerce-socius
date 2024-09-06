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

        [HttpGet("byCorreoClave")]
        public async Task<IActionResult> GetByCorreoClave(string correo, string clave)
        {
            var usuario = await _usuarioService.GetUsuarioByCorreoClaveAsync(correo, clave);
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

        [HttpPut("Update/Nombre/{id}/{nombre}")]
        public async Task<IActionResult> UpdateNombre(int id, string nombre)
        {

            var existingUsuario = await _usuarioService.GetByIdAsync(id);
            if (existingUsuario == null)
                return NotFound();

            // Intentar actualizar el nombre del usuario
            var updateResult = await _usuarioService.UpdateNombreUsuarioAsync(id, nombre);

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

        [HttpPut("Update/Clave/{id}/{clave}")]
        public async Task<IActionResult> UpdateClave(int id, string clave)
        {

            var existingUsuario = await _usuarioService.GetByIdAsync(id);
            if (existingUsuario == null)
                return NotFound();

            // Intentar actualizar el nombre del usuario
            var updateResult = await _usuarioService.UpdateClaveUsuarioAsync(id, clave);

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

        [HttpPut("Update/Habilitado/{id}/{habilitado}")]
        public async Task<IActionResult> UpdateHabilitado(int id, bool habilitado)
        {

            var existingUsuario = await _usuarioService.GetByIdAsync(id);
            if (existingUsuario == null)
                return NotFound();

            // Intentar actualizar el nombre del usuario
            var updateResult = await _usuarioService.UpdateHabilitaUsuarioAsync(id, habilitado);

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

        [HttpPut("Update/Eliminado/{id}/{eliminado}")]
        public async Task<IActionResult> UpdateEliminado(int id, bool eliminado ) 
        {

            var existingUsuario = await _usuarioService.GetByIdAsync(id);
            if (existingUsuario == null)
                return NotFound();

            // Intentar actualizar el nombre del usuario
            var updateResult = await _usuarioService.UpdateEliminaUsuarioAsync(id, eliminado);

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
