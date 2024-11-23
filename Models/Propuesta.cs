using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Actividad2_API_A2.Models
{
    public class Propuesta
    {
        [Key]
        public int IdPropuesta { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "El nombre del archivo no puede exceder los 255 caracteres")]
        public string ArchivoPropuesta { get; set; } = null!;

        [Required]
        [DataType(DataType.Date, ErrorMessage = "La fecha es inválida")]
        public DateTime FechaEnvio { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "El estado no puede exceder los 20 caracteres")]
        public string Estado { get; set; } = null!; 

        public int IdAsociado { get; set; }
        [ForeignKey(nameof(IdAsociado))]
        public Asociado Asociado { get; set; } = null!;
        
        public int IdOferta { get; set; }
        [ForeignKey(nameof(IdOferta))]
        public OfertaLaboral OfertaLaboral { get; set; } = null!;
    }

}
