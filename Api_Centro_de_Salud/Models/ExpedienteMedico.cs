using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Api_Centro_de_Salud.Models
{
    public class ExpedienteMedico
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Diagnostico { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Tratamiento { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Notas { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [DataType(DataType.Date)]
        public DateTime FechaRegistro { get; set; }

        [ForeignKey(nameof(Paciente))]
        public int IdPaciente { get; set; }
        public Paciente Paciente { get; set; }

        [ForeignKey(nameof(Medico))]
        public int IdMedico { get; set; }
        public Medico Medico { get; set; }
    }
}
