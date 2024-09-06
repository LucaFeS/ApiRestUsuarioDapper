using Application.Dto;
using AutoMapper;
using Domain.Models;
using WebApi.Dto;

namespace Application.Mappings
{ 
    public class Mapa : Profile
    {
        public Mapa()
        {
            CreateMap<Usuario, UsuarioDto>();
            CreateMap<Usuario, UsuarioCriarDto>();
            CreateMap<Usuario, UsuarioEditarDto>();





            //ResponseModel
            CreateMap<ResponseModel<List<Usuario>>, ResponseModel<List<UsuarioDto>>>();
            CreateMap<ResponseModel<List<Usuario>>, ResponseModel<List<UsuarioCriarDto>>>();
            CreateMap<ResponseModel<List<Usuario>>, ResponseModel<List<UsuarioEditarDto>>>();
            CreateMap<ResponseModel<Usuario>,ResponseModel<UsuarioDto>>();
        }

      
    }
}
