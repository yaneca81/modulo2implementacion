using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Practica2.Models
{
    public class Expediente
    {
        [Key]
        public int ExpedienteMedicoId { get; set; }

        [Required(ErrorMessage = "El campo es requerido"), DataType(DataType.Date)]
        public DateTime FechaCreacion { get; set; }

        [StringLength(500)]
        public string Alergias { get; set; }

        [StringLength(500)]
        public string Antecedentes { get; set; }

        [Required(ErrorMessage = "El grupo sanguineo es requerido")]
        [StringLength(60)]
        public string GrupoSanguineo { get; set; }

        public int PacienteId { get; set; }
        [ForeignKey(nameof(PacienteId))]
        public Paciente Paciente { get; set; }
    }
}
