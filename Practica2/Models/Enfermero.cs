using System.ComponentModel.DataAnnotations;

namespace Practica2.Models
{
    public class Enfermero
    {
        [Key]
        public int EnfermeroId { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(25)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El Apellido es requerido")]
        [StringLength(25)]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "El nro de licencia es requerido")]

        public int NumeroLicencia { get; set; }

        [Required(ErrorMessage = "El correo electronico es requerido")]
        [StringLength(25)]
        public string Email { get; set; }


        [Required(ErrorMessage = "El Telefono es requerido")]
        public int Telefono { get; set; }
    }
}
