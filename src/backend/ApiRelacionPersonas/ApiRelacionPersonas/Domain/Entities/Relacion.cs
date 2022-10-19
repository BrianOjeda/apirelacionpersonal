namespace ApiRelacionPersonas.Domain
{
    public class Relacion
    {
        public int Id { get; set; }
        public int PersonaId_Padre { get; set; }
        public int PersonaId_Hijo { get; set; }

        public Persona PersonaPadre { get; set; }
        public Persona PersonaHijo { get; set; }
        public int TipoRelacionId { get; set; }
    }
}
