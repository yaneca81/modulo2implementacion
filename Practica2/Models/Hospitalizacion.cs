using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Practica2.Models
{
    public class Hospitalizacion
    {
        [Key]
        public int HospitalizacionId { get; set; }

        [Required(ErrorMessage = "El campo es requerido"), DataType(DataType.Date)]
        public DateTime FechaIngreso { get; set; }

        
        public DateTime? FechaAlta { get; set; }

        [Required(ErrorMessage = "El estado de la hospitalizacion es requerido")]
        [StringLength(50)]
        public string Estado { get; set; }


        [Required(ErrorMessage = "El numero de habitacion es requerido")]
        [StringLength(100)]
        public string NumeroHabitacion { get; set; }

        [Required(ErrorMessage = "ingrese las observaciones")]
        [StringLength(200)]
        public string Observaciones { get; set; }

        public int PacienteId { get; set; }
        [ForeignKey(nameof(PacienteId))]
        public Paciente Paciente { get; set; }

        public int MedicoId { get; set; }
        [ForeignKey(nameof(MedicoId))]
        public Medico Medico { get; set; }

        public int EnfermeroId { get; set; }
        [ForeignKey(nameof(EnfermeroId))]
        public Enfermero Enfermero { get; set; }
    }
}
