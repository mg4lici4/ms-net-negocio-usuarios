using AutoMapper;
using UsuariosApi.DBContext;
using UsuariosApi.Models.DTOs;

namespace UsuariosApi.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UsuarioService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public UsuarioDto BusquedaPorIdUsuario(long idUsuario)
        {
            var usuario = _context.Usuarios.FirstOrDefault(x => x.IdUsuario.Equals(idUsuario));
            return _mapper.Map<UsuarioDto>(usuario);
        }

        public IEnumerable<UsuarioDto> ObtenerUsuarios()
        {
            var usuarios = _context.Usuarios
                           .OrderBy(u => u.IdUsuario)
                           .ToList();
            return _mapper.Map<List<UsuarioDto>>(usuarios);
        }
    }
}
