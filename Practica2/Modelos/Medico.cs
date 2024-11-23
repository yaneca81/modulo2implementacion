using System.ComponentModel.DataAnnotations;

namespace Practica2.Modelos
{
    public class Medico
    {
        [Key]
        public int id {  get; set; }
        [StringLength(20, ErrorMessage = "El campo debe tener un maximo 20 y un minimo de 3 caracteres", MinimumLength = 3)]
        [Required(ErrorMessage = "El campo es requerido")]
        public string Nombre { get; set; }
        [StringLength(20, ErrorMessage = "El campo debe tener un maximo 20 y un minimo de 3 caracteres", MinimumLength = 3)]
        [Required(ErrorMessage = "El campo es requerido")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(20, ErrorMessage = "El campo debe tener un maximo 20 y un minimo de 3 caracteres", MinimumLength = 3)]
        public string Especialidad { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        public int Telefono { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        [EmailAddress]
        public string Correo { get; set; }  
    }
}
