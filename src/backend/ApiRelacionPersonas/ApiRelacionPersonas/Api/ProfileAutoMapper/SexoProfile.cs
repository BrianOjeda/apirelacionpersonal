using ApiRelacionPersonas.Domain;
using AutoMapper;

namespace ApiRelacionPersonas.Api.ProfileAutoMapper
{
    public class SexoProfile : Profile
    {
        public SexoProfile()
        {
            CreateMap<Sexo, SexoResponseDto>();
        }
    }
}
