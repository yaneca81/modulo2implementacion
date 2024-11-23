using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Api_Centro_de_Salud.Models
{
    public class Notificacion
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Mensaje { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public bool Leida { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [DataType(DataType.Date)]
        public DateTime FechaEnvio { get; set; }

        [ForeignKey(nameof(Paciente))]
        public int IdPaciente { get; set; }
        public Paciente Paciente { get; set; }

        [ForeignKey(nameof(Medico))]
        public int IdMedico { get; set; }
        public Medico Medico { get; set; }
    }
}
