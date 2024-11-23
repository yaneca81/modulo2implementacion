using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaRecursosHumanos.Models
{
    public class Reporte
    {
        [Key]
        public int IdReporte { get; set; }

        public int IdEmpleado { get; set; }
        [ForeignKey(nameof(IdEmpleado))]
        public Empleado Empleado { get; set; }


        [Required(ErrorMessage = "La fecha del reporte es obligatoria")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "El tipo de reporte es obligatorio")]
        [StringLength(30, ErrorMessage = "El máximo es 30 caracteres")]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria")]
        [StringLength(500, ErrorMessage = "El máximo es 500 caracteres")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio")]
        [StringLength(20, ErrorMessage = "El máximo es 20 caracteres")]
        public string Estado { get; set; } // Ejemplo: "Pendiente", "Aprobado", "Rechazado"
    }
}
