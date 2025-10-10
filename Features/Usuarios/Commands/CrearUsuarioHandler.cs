using MediatR;
using UsuariosApi.Models.DTOs.Usuario;
using UsuariosApi.Services;

namespace UsuariosApi.Features.Usuarios.Commands
{
    public class CrearUsuarioHandler(IUsuarioService usuarioService, ILogger<CrearUsuarioHandler> logger) 
        : IRequestHandler<CrearUsuarioCommand, UsuarioDto>
    {
        private readonly IUsuarioService _usuarioService = usuarioService;
        private readonly ILogger<CrearUsuarioHandler> _logger = logger;

        public async Task<UsuarioDto> Handle(CrearUsuarioCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _usuarioService.CrearRegistroAsync(request.CrearUsuarioDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear usuario con nombre {Nombre}", request.CrearUsuarioDto.Nombre);
                throw;
            }
        }
    }
}
