using ApiRelacionPersonas.Domain;
using AutoMapper;

namespace ApiRelacionPersonas.Api.ProfileAutoMapper
{
    public class TipoRelacionProfile : Profile
    {
        public TipoRelacionProfile()
        {
            CreateMap<TipoRelacion, TipoRelacionResponseDto>();
        }
    }
}
