using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using UsuariosApi.Configuration;
using UsuariosApi.Helpers;
using UsuariosApi.Models.DTOs;

namespace UsuariosApi.controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly SettingsProvider _settingsProvider;

        public HomeController(SettingsProvider settingsProvider)
        {
            _settingsProvider = settingsProvider;
        }

        [HttpGet]
        public IActionResult ProbarConexion()
        {
            try
            {
                using var connection = new SqlConnection(_settingsProvider.DefaultConnectionString);
                connection.Open();


                if (connection.State == System.Data.ConnectionState.Open)
                    return Ok(new ApiResponseDto<string>
                    {
                        Datos = null,
                        Mensaje = MensajesHelper.CONEXION_BD_ABIERTA,
                        TiempoRespuesta = TiempoRespuestaHelper.ObtenerTiempo(HttpContext)
                    });
                else
                    return StatusCode(500, new ApiResponseDto<string>
                    {
                        Mensaje = MensajesHelper.CONEXION_BD_CERRADA,
                        Datos = null,
                        TiempoRespuesta = TiempoRespuestaHelper.ObtenerTiempo(HttpContext)
                    });
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