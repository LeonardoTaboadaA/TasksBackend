using AutoMapper;
using TasksBackend.DTO;
using TasksBackend.Entidades;

namespace TasksBackend.Utilidades
{
    public class AutoMapperProfiles: Profile    
    {
        public AutoMapperProfiles()
        {
            CreateMap<Equipo, EquipoDTO>().ReverseMap();
            CreateMap<Equipo, EquipoOpcionesDTO>().ReverseMap();
            CreateMap<EquipoRequest, Equipo>();
            CreateMap<ClienteRequest, Cliente>();
            CreateMap<ApplicationUser, UsuarioDTO>().ReverseMap();
            CreateMap<ApplicationUser, UsuarioResponse>().ReverseMap();
            CreateMap<UsuarioRequest, ApplicationUser>();
            CreateMap<UsuarioRequestEditar, ApplicationUser>();

        }
    }
}
