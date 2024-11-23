using System.ComponentModel.DataAnnotations;

namespace Actividad2_API_A2.Models
{
    public class Asociado
    {
        [Key]
        public int IdAsociado { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(50, ErrorMessage = "El nombre no puede exceder los 50 caracteres")]
        public string Nombre { get; set; } = null!;

        [Required(ErrorMessage = "El apellido es requerido")]
        [StringLength(50, ErrorMessage = "El apellido no puede exceder los 50 caracteres")]
        public string Apellido { get; set; } = null!;

        [Required(ErrorMessage = "El email es requerido")]
        [EmailAddress(ErrorMessage = "Formato de email inválido")]
        public string Email { get; set; } = null!;

        public int? Telefono { get; set; }

        [StringLength(255, ErrorMessage = "La dirección no puede exceder los 255 caracteres")]
        public string? Direccion { get; set; }
    }
}
