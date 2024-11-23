using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Actividad2_API_A2.Models
{
    public class Evento
    {
        [Key]
        public int IdEvento { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El nombre del evento no puede exceder los 100 caracteres")]
        public string NombreEvento { get; set; } = null!;

        [Required]
        [DataType(DataType.Date, ErrorMessage = "La fecha es inválida")]
        public DateTime Fecha { get; set; }

        [StringLength(255, ErrorMessage = "La ubicación no puede exceder los 255 caracteres")]
        public string? Ubicacion { get; set; }

        public string? Descripcion { get; set; }

        public int IdAsociado { get; set; }
        [ForeignKey(nameof(IdAsociado))]
        public Asociado Asociado { get; set; } = null!;
    }

}
