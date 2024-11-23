using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Api_Centro_de_Salud.Models
{
    public class Hospitalizacion
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Diagnostico { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(50, ErrorMessage = "El campo {0} debe tener maximo {1} y minimo {2}", MinimumLength = 2)]
        public string Habitacion { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [DataType(DataType.Date)]
        public DateTime FechaIngreso { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [DataType(DataType.Date)]
        public DateTime FechaAlta { get; set; }

        [ForeignKey(nameof(Paciente))]
        public int IdPaciente { get; set; }
        public Paciente Paciente { get; set; }

        [ForeignKey(nameof(Enfermero))]
        public int IdEnfermero { get; set; }
        public Enfermero Enfermero { get; set; }
    }
}
