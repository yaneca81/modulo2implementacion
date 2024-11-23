using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TeleMedicina.Models
{
    public class Paciente
    {
        [Key]
        public int IdPaciente { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(10, ErrorMessage = "El nombre no puede exceder los 10 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio")]
        [StringLength(10, ErrorMessage = "El apellido no puede exceder los 10 caracteres")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio"), DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "El telefono es obligatorio")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "La dirección es obligatoria")]
        public string Direccion { get; set; }
    }

}
