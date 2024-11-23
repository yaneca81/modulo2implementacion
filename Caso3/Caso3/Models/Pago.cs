using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Caso3.Models
{
    public class Pago
    {
        [Key]
        public int PagoId { get; set; }

        [Required]
        public int PedidoId { get; set; }

        [ForeignKey("PedidoId")]
        public Pedido Pedido { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Monto { get; set; }

        [Required]
        [StringLength(50)]
        public string MetodoPago { get; set; } // "Tarjeta", "PayPal", "Efectivo"

        [Required]
        public DateTime FechaPago { get; set; }
    }
}
