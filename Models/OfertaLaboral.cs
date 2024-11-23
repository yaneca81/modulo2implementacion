using System.ComponentModel.DataAnnotations;

namespace Actividad2_API_A2.Models
{
    public class OfertaLaboral
    {
        [Key]
        public int IdOferta { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El título no puede exceder los 100 caracteres")]
        public string Titulo { get; set; } = null!;

        [Required(ErrorMessage = "La descripción es requerida")]
        public string Descripcion { get; set; } = null!;

        [Required(ErrorMessage = "Los requisitos son requeridos")]
        public string Requisitos { get; set; } = null!;

        [Required]
        [DataType(DataType.Date, ErrorMessage = "La fecha es inválida")]
        public DateTime FechaPublicacion { get; set; }

        [Required]
        [DataType(DataType.Date, ErrorMessage = "La fecha es inválida")]
        public DateTime FechaLimite { get; set; }
    }

}
