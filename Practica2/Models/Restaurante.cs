using System.ComponentModel.DataAnnotations;

namespace Practica2.Models
{
    public class Restaurante
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(20, ErrorMessage = "El campo debe tener un maximo 20 y un minimo de ", MinimumLength = 5)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(20, ErrorMessage = "El campo debe tener un maximo 20 y un minimo de ", MinimumLength = 5)]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "El Teleno es requerido")]
        public int Telefono { get; set; }
    }
}
