using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Actividad2.Models
{
    public class Cita
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "La fecha de nacimiento es requerida")]
        //[DataType(DataType.Date)]
        public DateTime FechaHora { get; set; }
        [Required(ErrorMessage = "El campo motivo de la consulta es obligatorio")]
        [StringLength(50, ErrorMessage = "El maximo es 50 y minimo 6", MinimumLength = 10)]
        public string Motivo { get; set; }
        [Required(ErrorMessage = "El campo estado es obligatorio")]
        [StringLength(15, ErrorMessage = "El maximo es 15 y minimo 6", MinimumLength = 6)]
        public string Estado { get; set; }
        public int IdPaciente { get; set; }
        [ForeignKey(nameof(IdPaciente))]
        public Paciente Paciente { get; set; }
        public int IdDoctor { get; set; }
        [ForeignKey(nameof(IdDoctor))]
        public Doctor Doctor { get; set; }
    }
}
