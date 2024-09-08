using ecommerce.Model;
using ecommerce.Repository.Interfaces;
using ecommerce.Services.Interfaces;

namespace ecommerce.Services.Implementations
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<IEnumerable<TbUsuario>> GetAllUsuariosAsync()
        {
            return await _usuarioRepository.GetAllUsuariosAsync();
        }

        public async Task<TbUsuario?> GetByIdAsync(int id)
        {
            return await _usuarioRepository.GetByIdAsync(id);
        }

        public async Task<TbUsuario?> GetUsuarioByCorreoClaveAsync(string correo, string clave)
        {
            return await _usuarioRepository.GetUsuarioByCorreoClaveAsync(correo, clave);
        }

        public async Task<int> InsertUsuarioAsync(TbUsuario usuario)
        {
            return await _usuarioRepository.InsertUsuarioAsync(usuario);
        }

        public async Task<int> UpdateClaveUsuarioAsync(int usuarioId, string clave)
        {
            return await _usuarioRepository.UpdateClaveUsuarioAsync(usuarioId, clave);
        }

        public async Task<int> UpdateEliminaUsuarioAsync(int usuarioId, bool eliminado)
        {
            return await _usuarioRepository.UpdateEliminaUsuarioAsync(usuarioId, eliminado);
        }

        public async Task<int> UpdateHabilitaUsuarioAsync(int usuarioId, bool habilitado)
        {
            return await _usuarioRepository.UpdateHabilitaUsuarioAsync(usuarioId, habilitado);
        }

        public async Task<int> UpdateNombreUsuarioAsync(int usuarioId, string nombre)
        {
            return await _usuarioRepository.UpdateNombreUsuarioAsync(usuarioId, nombre);
        }

    }
}
