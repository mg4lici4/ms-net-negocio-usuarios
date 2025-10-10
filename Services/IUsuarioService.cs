using UsuariosApi.Models.DTOs.Usuario;

namespace UsuariosApi.Services
{
    public interface IUsuarioService
    {
        IEnumerable<UsuarioDto> ObtenerUsuarios();
        Task<UsuarioDto> BusquedaPorIdUsuarioAsync(long idUsuario);
        Task<UsuarioDto> CrearRegistroAsync(CrearUsuarioDto crearUsuarioDto);
    }
}
