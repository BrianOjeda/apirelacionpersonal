using ApiRelacionPersonas.Domain;
using AutoMapper;

namespace ApiRelacionPersonas.Api.ProfileAutoMapper
{
    public class TipoDocumentoProfile : Profile
    {
        public TipoDocumentoProfile()
        {
            CreateMap<TipoDocumento, TipoDocumentoResponseDto>();
        }
    }
}
