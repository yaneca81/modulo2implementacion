using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Actividad2_API_A2.Models
{
    public class CurriculumVitae
    {
        [Key]
        public int IdCv { get; set; }

        [Required]
        public byte[] ArchivoPdf { get; set; } = null!;

        [Required]
        [DataType(DataType.Date, ErrorMessage = "La fecha es inválida")]
        public DateTime FechaSubida { get; set; }

        public int IdAsociado { get; set; }
        [ForeignKey(nameof(IdAsociado))]
        public Asociado Asociado { get; set; } = null!;
    }
}
