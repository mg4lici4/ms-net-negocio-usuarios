using System;
using System.Diagnostics;

namespace UsuariosApi.Helpers;

public static class TiempoRespuestaHelper
{
    public static string ObtenerTiempo(HttpContext context)
    {
        if (context.Items.TryGetValue("Stopwatch", out var sw) && sw is Stopwatch stopwatch)
            return $"{stopwatch.ElapsedMilliseconds} ms";

        return "-1 ms";
    }
}
