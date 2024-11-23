using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Actividad2.Models
{
    public class Historial
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "La fecha de apertura es obligatorio")]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }
        [Required(ErrorMessage = "El campo estado es obligatorio")]
        [StringLength(10, ErrorMessage = "El maximo es 10 y minimo 5", MinimumLength = 5)]
        public string Estado { get; set; }
        public int IdPaciente { get; set; }
        [ForeignKey(nameof(IdPaciente))]
        public Paciente Paciente { get; set; }
    }
}
