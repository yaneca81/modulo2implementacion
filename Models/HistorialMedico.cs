using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TeleMedicina.Models
{
    public class HistorialMedico
    {
        [Key]
        public int IdHistorial { get; set; }

        [Required(ErrorMessage = "La fecha de registro es obligatoria")]
        [DataType(DataType.DateTime)]
        public DateTime FechaRegistro { get; set; }

        [Required(ErrorMessage = "El diagnóstico es obligatorio")]
        public string Diagnostico { get; set; }

        public string Notas { get; set; }

        public int IdPaciente { get; set; }

        [ForeignKey(nameof(IdPaciente))]
        public Paciente Paciente { get; set; }
    }

}
