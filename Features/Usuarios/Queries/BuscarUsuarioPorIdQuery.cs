using MediatR;
using UsuariosApi.Models.DTOs.Usuario;

namespace UsuariosApi.Features.Usuarios.Queries
{
    public record BuscarUsuarioPorIdQuery(long IdUsuario) : IRequest<UsuarioDto>;
}
