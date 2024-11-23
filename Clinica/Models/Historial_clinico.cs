using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Clinia.Models
{
    public class Historial_clinico
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]       
        public string Observaciones { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [DataType(DataType.Date)]
        public DateTime FechaRegistro { get; set; }

        public int IdPaciente { get; set; }
        [ForeignKey(nameof(IdPaciente))]
        public Paciente Paciente { get; set; }
    }
}
