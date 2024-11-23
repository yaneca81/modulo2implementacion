using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practica2.Modelos
{
    public class Cita
    {
        [Key ]
        public int Id { get; set; }
        [Required(ErrorMessage ="El campo es requerido")]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }
        [DataType(DataType.Time)]
        public DateTime Hora { get; set; }



        public int IdPaciente { get; set; }
        [ForeignKey(nameof(IdPaciente))]
        public Paciente Paciente { get; set; }

        public int IdMedico { get; set; }
        [ForeignKey(nameof(IdMedico))]
        public Medico Medico { get; set; }

        [Required(ErrorMessage ="Campo requerido")]
        [StringLength(20, ErrorMessage = "El campo debe tener un maximo 20 y un minimo de 3 caracteres", MinimumLength =5 )]
        public string Estado { get; set; }

    }
}
