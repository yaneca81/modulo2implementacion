using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Actividad2_API_A2.Models
{
    public class Cuota
    {
        [Key]
        public int IdCuota { get; set; }

        [Required]
        [Range(0.01, 10000, ErrorMessage = "El monto debe ser mayor a 0 y menor a 10,000")]
        public decimal Monto { get; set; }

        [Required]
        [DataType(DataType.Date, ErrorMessage = "La fecha es inválida")]
        public DateTime FechaPago { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "El estado no puede exceder los 20 caracteres")]
        public string Estado { get; set; } = null!; 

        public int IdAsociado { get; set; }
        [ForeignKey(nameof(IdAsociado))]
        public Asociado Asociado { get; set; } = null!;
    }

}
