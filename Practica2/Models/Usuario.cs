using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Practica2.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El Nombre es requerido")]
        [StringLength(20, ErrorMessage = "El campo debe tener un maximo 20 y un minimo de 3 ", MinimumLength = 3)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El Apellido es requerido")]
        [StringLength(20, ErrorMessage = "El campo debe tener un maximo 20 y un minimo de 3 ", MinimumLength = 3)]
        public string Aprellido { get; set; }
        [Required(ErrorMessage = "El Apellido es requerido")]
        [StringLength(20, ErrorMessage = "El campo debe tener un maximo 20 y un minimo de 3 ", MinimumLength = 3)]
        public string Correo { get; set; }
        [Required(ErrorMessage = "La contraseña es requerida")]
        [StringLength(20, ErrorMessage = "El campo debe tener un maximo 20 y un minimo de 8 ", MinimumLength = 8)]
        public string Contraseña { get; set; }
        [Required(ErrorMessage = "El Teleno es requerido")]
        public int Telefono { get; set; }
        [Required(ErrorMessage = "La contraseña es requerida")]
        [StringLength(20, ErrorMessage = "El campo debe tener un maximo 20 y un minimo de 8 ", MinimumLength = 8)]
        public string Rol { get; set; }
    }
}
