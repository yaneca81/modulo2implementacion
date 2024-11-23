using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TeleMedicina.Models
{
    public class Cita
    {
        [Key]
        public int IdCita { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio"), DataType(DataType.Date)]
        public DateTime FechaHora { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio")]
        public string Estado { get; set; } 

        [Required(ErrorMessage = "El motivo es obligatorio")]
        public string Motivo { get; set; }

        public int IdPaciente { get; set; }  
        [ForeignKey(nameof(IdPaciente))]
        public Paciente Paciente { get; set; }

        public int IdMedico { get; set; }  
        [ForeignKey(nameof(IdMedico))]
        public Medico Medico { get; set; }
    }

}
