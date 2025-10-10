using MediatR;
using UsuariosApi.Models.DTOs;

namespace UsuariosApi.Features.Usuarios.Queries
{
    public record ObtenerTodosUsuariosQuery() : IRequest<IEnumerable<UsuarioDto>>;
}
