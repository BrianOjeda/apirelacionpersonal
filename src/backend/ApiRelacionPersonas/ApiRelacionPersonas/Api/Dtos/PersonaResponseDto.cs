namespace ApiRelacionPersonas.Api
{
    public class PersonaResponseDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NumeroDocumento { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string TipoDocumento { get; set; }
        public string Nacionalidad { get; set; }
        public string Sexo { get; set; }
    }
}
