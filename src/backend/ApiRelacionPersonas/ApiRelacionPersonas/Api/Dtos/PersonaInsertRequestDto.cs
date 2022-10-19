using ApiRelacionPersonas.Domain;
using System.ComponentModel.DataAnnotations;

namespace ApiRelacionPersonas.Api
{
    public class PersonaInsertRequestDto : IValidatableObject
    {       
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        [Required(ErrorMessage ="El {0} es Requerido!!")]
        public string NumeroDocumento { get; set; }
        [Required(ErrorMessage = "El {0} es Requerido!!")]
        public DateTime FechaNacimiento { get; set; }
        [Required(ErrorMessage = "El {0} es Requerido!!")]
        public int TipoDocumentoId { get; set; }
        [Required(ErrorMessage = "El {0} es Requerido!!")]
        public int NacionalidadId { get; set; }
        [Required(ErrorMessage = "El {0} es Requerido!!")]
        public int SexoId { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            DateTime hoy = DateTime.Today;
            int anio = hoy.Year - FechaNacimiento.Year;

            if (FechaNacimiento.AddYears(anio) > hoy)
                anio--;

            if (anio < 18)
                 yield return new ValidationResult("La persona debe ser mayor a 18 años", 
                                                new string[] {nameof(FechaNacimiento)});
        }
    }
}
