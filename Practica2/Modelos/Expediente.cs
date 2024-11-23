using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Practica2.Modelos
{
    public class Expediente
    {
      
        [Key]
        public int Id { get; set; }
       
        public int IdPaciente { get; set; }
        [ForeignKey(nameof(IdPaciente))]
        public Paciente Paciente { get; set; }

        public int IdMedico { get; set; }
        [ForeignKey(nameof(IdMedico))]
        public Medico Medico { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [StringLength(30, ErrorMessage = "El campo debe tener un maximo 30 y un minimo de 10 caracteres", MinimumLength = 10)]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        [DataType(DataType.Date)]
        public DateTime Fecha_actualizacion { get; set; }
    }
}
