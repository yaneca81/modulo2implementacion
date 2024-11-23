using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations;

namespace SistemaRecursosHumanos.Models
{
    public class Empleado
    {
        [Key]
        public int IdEmpleado { get; set; }

        [Required(ErrorMessage = "El CI es obligatorio")]
        [StringLength(10, ErrorMessage = "El máximo es 10 y el mínimo 7", MinimumLength = 7)]
        public string CI { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(20, ErrorMessage = "El máximo es 20 y el mínimo 3", MinimumLength = 3)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio")]
        [StringLength(20, ErrorMessage = "El máximo es 20 y el mínimo 3", MinimumLength = 3)]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El cargo es obligatorio")]
        [StringLength(30, ErrorMessage = "El máximo es 30 y el mínimo 5", MinimumLength = 5)]
        public string Cargo { get; set; }

        [Required(ErrorMessage = "El salario es obligatorio")]
        [Range(0, double.MaxValue, ErrorMessage = "El salario debe ser un valor positivo")]
        public decimal Salario { get; set; }

        [Required(ErrorMessage = "La fecha de contratación es obligatoria")]
        public DateTime FechaContratacion { get; set; }

        [Required(ErrorMessage = "La dirección es obligatoria")]
        [StringLength(50, ErrorMessage = "El máximo es 50 y el mínimo 10", MinimumLength = 10)]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio")]
        [StringLength(15, ErrorMessage = "El máximo es 15 caracteres")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El correo electrónico es obligatorio")]
        [EmailAddress(ErrorMessage = "El formato del correo no es válido")]
        public string CorreoElectronico { get; set; }
    }
}

