using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Helpers;
using UsuariosApi.Models.DTOs;
using UsuariosApi.Services;

namespace UsuariosApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;   
        }

        [HttpGet]
        public IActionResult ObtenerTodos()
        {
            try
            {
                var usuarios = _usuarioService.ObtenerUsuarios();

                if (usuarios.Any())
                    return Ok(new ApiResponseDto<List<UsuarioDto>>
                    {
                        Datos = usuarios,
                        Mensaje = MensajesHelper.OPERACION_CORRECTA,
                        TiempoRespuesta = TiempoRespuestaHelper.ObtenerTiempo(HttpContext)
                    });
                else
                    return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, new ApiResponseDto<string>
                {
                    Mensaje = MensajesHelper.ERROR_INTERNO_SERVIDOR,
                    Datos = null,
                    TiempoRespuesta = TiempoRespuestaHelper.ObtenerTiempo(HttpContext)
                });
            }
        }
    }
}
