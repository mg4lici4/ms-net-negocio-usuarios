using MediatR;
using UsuariosApi.Models.DTOs.Usuario;
using UsuariosApi.Services;

namespace UsuariosApi.Features.Usuarios.Queries
{
    public class ObtenerTodosUsuariosHandler(IUsuarioService usuarioService, ILogger<ObtenerTodosUsuariosHandler> logger) 
        : IRequestHandler<ObtenerTodosUsuariosQuery, IEnumerable<UsuarioDto>>
    {
        private readonly IUsuarioService _usuarioService = usuarioService;
        private readonly ILogger<ObtenerTodosUsuariosHandler> _logger = logger;

        public Task<IEnumerable<UsuarioDto>> Handle(ObtenerTodosUsuariosQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var usuarios = _usuarioService.ObtenerUsuarios();
                return Task.FromResult(usuarios);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en ObtenerTodosUsuariosHandler");
                throw;
            }
        }
    }
}
