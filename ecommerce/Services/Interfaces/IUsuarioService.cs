using ecommerce.Model;

namespace ecommerce.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<IEnumerable<TbUsuario>> GetAllUsuariosAsync();
        Task<TbUsuario?> GetByIdAsync(int id);
        Task<int> InsertUsuarioAsync(TbUsuario usuario);
        Task<TbUsuario?> GetUsuarioByCorreoClaveAsync(string correo, string clave);
        Task<int> UpdateHabilitaUsuarioAsync(int usuarioId, bool habilitado);
        Task<int> UpdateEliminaUsuarioAsync(int usuarioId, bool eliminado);
        Task<int> UpdateClaveUsuarioAsync(int usuarioId, string clave);
        Task<int> UpdateNombreUsuarioAsync(int usuarioId, string nombre);

    }
}
