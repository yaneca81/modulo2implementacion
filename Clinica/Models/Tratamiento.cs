using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Clinia.Models
{
    public class Tratamiento
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        [DataType(DataType.Date)]
        public DateTime FechaInicio { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        [DataType(DataType.Date)]
        public DateTime FechaFin { get; set; }

        public int IdPaciente { get; set; }
        [ForeignKey(nameof(IdPaciente))]
        public Paciente Paciente { get; set; }

        public int IdMedico { get; set; }
        [ForeignKey(nameof(IdMedico))]
        public Medico Medico { get; set; }

        public int IdHistorialClinico { get; set; } 
        [ForeignKey(nameof(IdHistorialClinico))]
        public Historial_clinico Historial_Clinico { get; set; }
    }
}
