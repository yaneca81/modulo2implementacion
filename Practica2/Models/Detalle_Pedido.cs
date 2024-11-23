using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practica2.Models
{
    public class Detalle_Pedido
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        [Range(20, 200)]
        public int Cantidad { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        [Range(20, 200)]
        public int Sub_Total { get; set; }
        public int IdPedido { get; set; }
        [ForeignKey(nameof(IdPedido))]
        public Pedido Pedido { get; set; }
        public int IdPlatillo { get; set; }
        [ForeignKey(nameof(IdPlatillo))]
        public Platillo Platillo { get; set; }
    }
}
