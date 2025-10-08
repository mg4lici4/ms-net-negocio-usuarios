using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Helpers;
using UsuariosApi.Services;

namespace UsuariosApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly ILogger<UsuariosController> _logger;
        private readonly IUsuarioService _usuarioService;
        public UsuariosController(IUsuarioService usuarioService, 
            ILogger<UsuariosController> logger)
        {
            _logger = logger;
            _usuarioService = usuarioService;   
        }

        [HttpGet]
        public IActionResult ObtenerTodos()
        {
            try
            {
                var usuarios = _usuarioService.ObtenerUsuarios();

                if (usuarios.Any())
                    return Ok(ResponseHelper.OperacionCorrecta(usuarios, HttpContext));
                else
                    return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en ObtenerTodos");
                return StatusCode(500, ResponseHelper.ErrorInternoDelServidor(HttpContext));
            }
        }

        [HttpGet("{idUsuario}")]
        public IActionResult BuscarPorIdUsuario(long idUsuario)
        {
            try
            {
                var usuario = _usuarioService.BusquedaPorIdUsuario(idUsuario);
                if(usuario is not null)
                    return Ok(ResponseHelper.OperacionCorrecta(usuario, HttpContext));

                return NotFound(ResponseHelper.RecursoNoEncontrado(MensajesHelper.USUARIO_NO_ENCONTRADO, HttpContext));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en BuscarPorIdUsuario con idUsuario {idUsuario}", idUsuario);
                return StatusCode(500, ResponseHelper.ErrorInternoDelServidor(HttpContext));
            }
        }
    }
}
