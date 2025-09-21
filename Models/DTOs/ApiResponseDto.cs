using System;

namespace UsuariosApi.Models.DTOs;

public class ApiResponseDto<T>
{
    public string Mensaje { get; set; } = string.Empty;
    public T? Datos { get; set; }
    public string TiempoRespuesta { get; set; } = string.Empty;
}