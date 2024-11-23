using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaRecursosHumanos.Models
{
    public class Capacitacion
    {
        [Key]
        public int IdCapacitacion { get; set; }

        [Required(ErrorMessage = "El ID del empleado es obligatorio")]

        public int IdEmpleado { get; set; }
        [ForeignKey(nameof(IdEmpleado))]
        public Empleado Empleado { get; set; }


        [Required(ErrorMessage = "El título de la capacitación es obligatorio")]
        [StringLength(50, ErrorMessage = "El máximo es 50 caracteres")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "La fecha de inicio es obligatoria")]
        public DateTime FechaInicio { get; set; }

        [Required(ErrorMessage = "La fecha de fin es obligatoria")]
        public DateTime FechaFin { get; set; }

        [Required(ErrorMessage = "El estado de la capacitación es obligatorio")]
        [StringLength(20, ErrorMessage = "El máximo es 20 caracteres")]
        public string Estado { get; set; } // Ejemplo: "Completada", "En curso", "Cancelada"

        [StringLength(500, ErrorMessage = "El máximo es 500 caracteres")]
        public string Descripcion { get; set; } // Detalles adicionales sobre la capacitación
    }
}
