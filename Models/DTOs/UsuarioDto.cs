namespace UsuariosApi.Models.DTOs
{
    public class UsuarioDto
    {
        public long IdUsuario { get; set; }
        public string Nombre { get; set; }
        public int IdAplicacion { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
