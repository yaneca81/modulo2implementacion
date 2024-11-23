using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaRecursosHumanos.Models
{
    public class Nomina
    {
        [Key]
        public int IdNomina { get; set; }

        public int IdEmpleado { get; set; }
        [ForeignKey(nameof(IdEmpleado))]
        public Empleado Empleado { get; set; }


        [Required(ErrorMessage = "El mes es obligatorio")]
        [StringLength(10, ErrorMessage = "El máximo es 10 caracteres")]
        public string Mes { get; set; }

        [Required(ErrorMessage = "El año es obligatorio")]
        [Range(1900, 2100, ErrorMessage = "El año debe estar entre 1900 y 2100")]
        public int Anio { get; set; }

        [Required(ErrorMessage = "El salario bruto es obligatorio")]
        [Range(0, double.MaxValue, ErrorMessage = "El salario bruto debe ser un valor positivo")]
        public decimal SalarioBruto { get; set; }

        [Required(ErrorMessage = "Las deducciones son obligatorias")]
        [Range(0, double.MaxValue, ErrorMessage = "Las deducciones deben ser un valor positivo")]
        public decimal Deducciones { get; set; }

        [Required(ErrorMessage = "Las bonificaciones son obligatorias")]
        [Range(0, double.MaxValue, ErrorMessage = "Las bonificaciones deben ser un valor positivo")]
        public decimal Bonificaciones { get; set; }

        [Required(ErrorMessage = "El salario neto es obligatorio")]
        [Range(0, double.MaxValue, ErrorMessage = "El salario neto debe ser un valor positivo")]
        public decimal SalarioNeto { get; set; }

        [Required(ErrorMessage = "La fecha de generación es obligatoria")]
        public DateTime FechaGeneracion { get; set; }
    }
}
