using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Actividad2.Models
{
    public class Tratamiento
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "La fecha de inicio de tratamiento es requerida")]
        [DataType(DataType.Date)]
        public DateTime FechaInicio { get; set; }
        
        [Required(ErrorMessage = "La fecha de finalizacion de tratamiento es requerida")]
        [DataType(DataType.Date)]
        public DateTime FechaFin { get; set; }
        [Required(ErrorMessage = "El campo Prescripcion Medicamentos es obligatorio")]
        [StringLength(500, ErrorMessage = "El maximo es 500 y minimo 10", MinimumLength = 10)]
        public string PrescripcionMedicamentos { get; set; }
        [Required(ErrorMessage = "El campo Recomendaciones es obligatorio")]
        [StringLength(500, ErrorMessage = "El maximo es 500 y minimo 10", MinimumLength = 10)]
        public string Recomendaciones { get; set; }
        public int IdHistorial { get; set; }
        [ForeignKey(nameof(IdHistorial))]
        public Historial Historial { get; set; }
    }
}
