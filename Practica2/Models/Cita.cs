using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practica2.Models
{
    public class Cita
    {
        [Key]
        public int CitaId { get; set; }

        [Required(ErrorMessage = "El campo es requerido"),DataType(DataType.Date)]
        public DateTime FechaCita {  get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(25)]
        public string Estado { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(150)]
        public string Observaciones { get; set; }

        public int PacienteId { get; set; }
        [ForeignKey(nameof(PacienteId))]
        public Paciente Paciente { get; set; }

        public int MedicoId { get; set; }
        [ForeignKey(nameof(MedicoId))]
        public Medico Medico { get; set; }


    }
}
