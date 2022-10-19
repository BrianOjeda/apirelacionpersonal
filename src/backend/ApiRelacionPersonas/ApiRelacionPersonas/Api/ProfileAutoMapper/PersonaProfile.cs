using AutoMapper;
using ApiRelacionPersonas.Domain;

namespace ApiRelacionPersonas.Api
{
    public class PersonaProfile: Profile
    {
        public PersonaProfile()
        {
            CreateMap<PersonaInsertRequestDto, Persona>();
            CreateMap<PersonaUpdateRequestDto, Persona>();

            CreateMap<Persona,PersonaResponseDto> ()
                        .ForMember(dto => dto.Sexo,
                                        opt => opt.MapFrom(dst => dst.Sexo.Nombre))
                        .ForMember(dto=>dto.TipoDocumento,
                                        opt => opt.MapFrom(dst=> dst.TipoDocumento.Tipo))
                        .ForMember(dto=>dto.Nacionalidad,
                                        opt=>opt.MapFrom(dst=>dst.Nacionalidad.Nombre));
        }
    }
}
