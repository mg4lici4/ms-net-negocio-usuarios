namespace UsuariosApi.Models.Entities
{
    public class UsuarioEntity
    {
        public long IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Contrasenia { get; set; }
        public int IdAplicacion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaModificacion { get; set; }

    }
}
