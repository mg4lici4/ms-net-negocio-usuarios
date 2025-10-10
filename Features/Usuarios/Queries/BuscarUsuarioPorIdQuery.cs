using MediatR;
using UsuariosApi.Models.DTOs;

namespace UsuariosApi.Features.Usuarios.Queries
{
    public record BuscarUsuarioPorIdQuery(long IdUsuario) : IRequest<UsuarioDto>;
}
