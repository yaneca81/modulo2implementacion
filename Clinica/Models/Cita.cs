using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Clinia.Models
{
    public class Cita
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="el campo es requerido")]
        public string Motivo { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        [DataType(DataType.DateTime)]      
        public DateTime Fecha_cita { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        public string Estado { get; set; } //Cita => Pendiente, finalizada, cancelada

        public int IdPaciente { get; set; }
        [ForeignKey(nameof(IdPaciente))]
        public Paciente Paciente { get; set; }

        public int IdMedico { get; set; }
        [ForeignKey(nameof(IdMedico))]
        public Medico Medico { get; set; }
    }
}
