using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Clinia.Models
{
    public class VideoLlamada
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        [DataType(DataType.DateTime)]
        public DateTime FechaHora { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        public string Estado { get; set; } //Llamada => En Curso, Finalizada, Cancelada
        [Required(ErrorMessage = "El campo es requerido")]
        public string Enlace { get; set; } // su url
        public int IdCita { get; set; }
        [ForeignKey(nameof(IdCita))]
        public Cita Cita { get; set; }

        public int IdPaciente { get; set; }
        [ForeignKey(nameof(IdPaciente))]
        public Paciente Paciente { get; set; }

        public int IdMedico { get; set; }
        [ForeignKey(nameof(IdMedico))]
        public Medico Medico { get; set; }
    }
}
