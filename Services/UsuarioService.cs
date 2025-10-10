using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using UsuariosApi.DBContext;
using UsuariosApi.Models.DTOs.Usuario;
using UsuariosApi.Models.Entities;

namespace UsuariosApi.Services
{
    public class UsuarioService(AppDbContext context, IMapper mapper) : IUsuarioService
    {
        private readonly AppDbContext _context = context;
        private readonly IMapper _mapper = mapper;

        public async Task<UsuarioDto> BusquedaPorIdUsuarioAsync(long idUsuario)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.IdUsuario.Equals(idUsuario));
            return _mapper.Map<UsuarioDto>(usuario);
        }

        public async Task<UsuarioDto> CrearRegistroAsync(CrearUsuarioDto crearUsuarioDto)
        {
            var usuarioEntity = _mapper.Map<UsuarioEntity>(crearUsuarioDto);
            await _context.Usuarios.AddAsync(usuarioEntity);
            await _context.SaveChangesAsync();
            return _mapper.Map<UsuarioDto>(usuarioEntity);
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
