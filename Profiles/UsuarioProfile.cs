using AutoMapper;
using UsuariosApi.Models.DTOs.Usuario;
using UsuariosApi.Models.Entities;

namespace UsuariosApi.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<UsuarioEntity, UsuarioDto>();

            CreateMap<CrearUsuarioDto,UsuarioEntity>();
        }
    }
}
