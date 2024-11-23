using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TeleMedicina.Models
{
    public class Tratamiento
    {
        [Key]
        public int IdTratamiento { get; set; }

        [Required(ErrorMessage = "El nombre del medicamento es obligatorio")]
        public string NombreMedicamento { get; set; }

        [Required(ErrorMessage = "La dosis es obligatoria")]
        public string Dosis { get; set; }

        [Required(ErrorMessage = "La frecuencia es obligatoria")]
        public string Frecuencia { get; set; }

        [Required(ErrorMessage = "La duración es obligatoria")]
        public string Duracion { get; set; }

        public int IdHistorial { get; set; }

        [ForeignKey(nameof(IdHistorial))]
        public HistorialMedico HistorialMedico { get; set; }
    }

}
