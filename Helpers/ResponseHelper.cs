using System.Runtime.CompilerServices;
using UsuariosApi.Models.DTOs;

namespace UsuariosApi.Helpers
{
    public static class ResponseHelper
    {
        public static ApiResponseDto<T> OperacionCorrecta<T>(T datos, HttpContext context) => 
            new ()
            {
                Datos = datos,
                Mensaje = MensajesHelper.OPERACION_CORRECTA,
                TiempoRespuesta = TiempoRespuestaHelper.ObtenerTiempo(context)
            };

        public static ApiResponseDto<object> RecursoNoEncontrado(string mensaje, HttpContext context) =>
            new()
            {
                Mensaje = mensaje,
                TiempoRespuesta = TiempoRespuestaHelper.ObtenerTiempo(context)
            };

        public static ApiResponseDto<object> ErrorInternoDelServidor(HttpContext context) =>
            new()
            {
                Mensaje = MensajesHelper.ERROR_INTERNO_SERVIDOR,
                TiempoRespuesta = TiempoRespuestaHelper.ObtenerTiempo(context)
            };
    }
}
