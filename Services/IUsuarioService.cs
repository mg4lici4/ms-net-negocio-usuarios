using UsuariosApi.Models.DTOs.Usuario;

namespace UsuariosApi.Services
{
    public interface IUsuarioService
    {
        Task<IEnumerable<UsuarioDto>> ObtenerRegistrosAsync();
        Task<UsuarioDto> BusquedaPorIdUsuarioAsync(long idUsuario);
        Task<UsuarioDto> CrearRegistroAsync(CrearUsuarioDto crearUsuarioDto);
    }
}
