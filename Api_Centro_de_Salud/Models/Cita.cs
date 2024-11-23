using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Api_Centro_de_Salud.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.EntityFrameworkCore;

namespace Api_Centro_de_Salud.Models
{
    public class Cita
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Motivo { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(50, ErrorMessage = "El campo {0} debe tener maximo {1} y minimo {2}", MinimumLength = 3)]
        public string Estado { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        [ForeignKey(nameof(Paciente))]
        public int IdPaciente { get; set; }
        public Paciente Paciente { get; set; }

        [ForeignKey(nameof(Medico))]
        public int IdMedico { get; set; }
        public Medico Medico { get; set; }
    }
}
