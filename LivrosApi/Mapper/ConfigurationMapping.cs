using AutoMapper;
using LivrosApi.Models;
using LivrosApi.Models.Dto;

namespace LivrosApi.Mapper
{
    public class ConfigurationMapping : Profile
    {
        public ConfigurationMapping()
        {
            CreateMap<Usuario, UsuarioDto>().ReverseMap();
        }
    }
}
