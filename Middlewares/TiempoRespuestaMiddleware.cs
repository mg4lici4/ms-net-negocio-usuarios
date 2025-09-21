using System;
using System.Diagnostics;

namespace UsuariosApi.Middlewares;

public class TiempoRespuestaMiddleware
{
    private readonly RequestDelegate _next;

    public TiempoRespuestaMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var stopwatch = Stopwatch.StartNew();
        context.Items["Stopwatch"] = stopwatch;

        await _next(context);

        stopwatch.Stop();
        context.Items["TiempoRespuestaMs"] = stopwatch.ElapsedMilliseconds;
    }
}