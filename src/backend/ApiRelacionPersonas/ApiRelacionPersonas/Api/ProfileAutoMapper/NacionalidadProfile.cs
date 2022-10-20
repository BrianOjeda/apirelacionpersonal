using ApiRelacionPersonas.Domain;
using AutoMapper;

namespace ApiRelacionPersonas.Api.ProfileAutoMapper
{
    public class NacionalidadProfile:Profile
    {
        public NacionalidadProfile()
        {
            CreateMap<Nacionalidad, NacionalidadResponseDto>();
        }
    }
}
