using MediatR;
using UsuariosApi.Models.DTOs.Usuario;

namespace UsuariosApi.Features.Usuarios.Commands
{
    public record CrearUsuarioCommand(CrearUsuarioDto CrearUsuarioDto) : IRequest<UsuarioDto>;
}
