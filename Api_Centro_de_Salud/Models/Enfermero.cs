using System.ComponentModel.DataAnnotations;

namespace Api_Centro_de_Salud.Models
{
    public class Enfermero
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(50, ErrorMessage = "El campo {0} debe tener maximo {1} y minimo {2}", MinimumLength = 3)]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(50, ErrorMessage = "El campo {0} debe tener maximo {1} y minimo {2}", MinimumLength = 3)]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(30, ErrorMessage = "El campo {0} debe tener maximo {1} y minimo {2}", MinimumLength = 4)]
        public string Telefono { get; set; }

        [EmailAddress(ErrorMessage = "El campo {0} no tiene un formato válido.")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [DataType(DataType.Date)]
        public DateTime FechaIngreso { get; set; }
    }
}
