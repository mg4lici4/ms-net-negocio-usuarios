using MediatR;
using UsuariosApi.Models.DTOs.Usuario;

namespace UsuariosApi.Features.Usuarios.Queries
{
    public record ObtenerTodosUsuariosQuery() : IRequest<IEnumerable<UsuarioDto>>;
}
