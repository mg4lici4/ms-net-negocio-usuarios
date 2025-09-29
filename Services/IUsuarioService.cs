using UsuariosApi.Models.DTOs;

namespace UsuariosApi.Services
{
    public interface IUsuarioService
    {
        List<UsuarioDto> ObtenerUsuarios();
    }
}
