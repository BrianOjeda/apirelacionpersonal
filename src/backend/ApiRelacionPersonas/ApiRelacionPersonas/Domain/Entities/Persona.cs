
using ApiRelacionPersonas.Domain;

namespace ApiRelacionPersonas.Domain
{
    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NumeroDocumento { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int TipoDocumentoId { get; set; }
        public int NacionalidadId { get; set; }
        public int SexoId { get; set; }
        public Sexo Sexo { get; set; }
        public TipoDocumento TipoDocumento { get; set; }
        public Nacionalidad Nacionalidad { get; set; }
    }
}
