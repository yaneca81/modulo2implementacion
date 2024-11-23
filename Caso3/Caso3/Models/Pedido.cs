using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Caso3.Models
{
    public class Pedido
    {
        [Key]
        public int PedidoId { get; set; }

        [Required]
        public int UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }

        [Required]
        public int RestauranteId { get; set; }

        [ForeignKey("RestauranteId")]
        public Restaurante Restaurante { get; set; }

        [Required]
        public DateTime FechaPedido { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }

        [Required]
        [StringLength(50)]
        public string Estado { get; set; } // "Pendiente", "En preparación", "Entregado"
        public ICollection<DetallePedido> Detalles { get; set; }
    }
}
