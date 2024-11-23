using System.ComponentModel.DataAnnotations;

namespace Clinica.Models
{
    public abstract class Persona
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El Nombre es requerido")]
        [StringLength(20, ErrorMessage = "El campo debe tener un máximo de 20 caracteres y un minimo de 3", MinimumLength = 3)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El Apellido es requerido")]
        [StringLength(20, ErrorMessage = "El campo debe tener un máximo de 20 caracteres y un minimo de 3", MinimumLength = 3)]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido")]
        public string Email { get; set; }
    }
}
