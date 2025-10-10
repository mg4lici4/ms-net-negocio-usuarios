using MediatR;
using UsuariosApi.Models.DTOs;
using UsuariosApi.Services;

namespace UsuariosApi.Features.Usuarios.Queries
{
    public class BuscarUsuarioPorIdHandler : IRequestHandler<BuscarUsuarioPorIdQuery, UsuarioDto?>
    {
        private readonly IUsuarioService _usuarioService;
        private readonly ILogger<BuscarUsuarioPorIdHandler> _logger;

        public BuscarUsuarioPorIdHandler(IUsuarioService usuarioService, ILogger<BuscarUsuarioPorIdHandler> logger)
        {
            _usuarioService = usuarioService;
            _logger = logger;
        }

        public Task<UsuarioDto> Handle(BuscarUsuarioPorIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var usuario = _usuarioService.BusquedaPorIdUsuario(request.IdUsuario);
                return Task.FromResult(usuario);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en BuscarUsuarioPorIdHandler con idUsuario {idUsuario}", request.IdUsuario);
                throw;
            }
        }
    }
}
