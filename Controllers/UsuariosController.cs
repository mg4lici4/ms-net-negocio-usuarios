using MediatR;
using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Features.Usuarios.Commands;
using UsuariosApi.Features.Usuarios.Queries;
using UsuariosApi.Helpers;
using UsuariosApi.Models.DTOs.Usuario;

namespace UsuariosApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsuariosController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var usuarios = await _mediator.Send(new ObtenerTodosUsuariosQuery());

            if (usuarios.Any())
                return Ok(ResponseHelper.OperacionCorrecta(usuarios, HttpContext));
            else
                return NoContent();
        }

        [HttpGet("{idUsuario}")]
        public async Task<IActionResult> BuscarPorIdUsuario(long idUsuario)
        {
            var usuario = await _mediator.Send(new BuscarUsuarioPorIdQuery(idUsuario));

            if (usuario is not null)
                return Ok(ResponseHelper.OperacionCorrecta(usuario, HttpContext));

            return NotFound(ResponseHelper.RecursoNoEncontrado(MensajesHelper.USUARIO_NO_ENCONTRADO, HttpContext));
        }

        [HttpPost]
        public async Task<IActionResult> CrearUsuario([FromBody] CrearUsuarioDto crearUsuarioDto)
        {
            var usuario = await _mediator.Send(new CrearUsuarioCommand(crearUsuarioDto));
            return Ok(ResponseHelper.OperacionCorrecta(usuario, HttpContext));
        }
    }
}
