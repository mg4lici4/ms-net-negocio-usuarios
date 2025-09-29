using AutoMapper;
using UsuariosApi.Models.DTOs;
using UsuariosApi.Models.Entities;

namespace UsuariosApi.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<UsuarioEntity, UsuarioDto>();
        }
    }
}
