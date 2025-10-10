using UsuariosApi.Models.DTOs;

namespace UsuariosApi.Services
{
    public interface IUsuarioService
    {
        IEnumerable<UsuarioDto> ObtenerUsuarios();
        UsuarioDto BusquedaPorIdUsuario(long idUsuario);
    }
}
