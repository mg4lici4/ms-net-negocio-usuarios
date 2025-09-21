using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace UsuariosApi.controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult ProbarConexion()
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection");

            try
            {
                using var connection = new SqlConnection(connectionString);
                connection.Open();

                if (connection.State == System.Data.ConnectionState.Open)
                    return Ok("✅ Conexión exitosa a SQL Server");
                else
                    return StatusCode(500, "❌ No se pudo abrir la conexión");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"❌ Error al conectar: {ex.Message}");
            }
        }
    }
}