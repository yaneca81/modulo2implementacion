using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practica2.Models
{
    public class Pago
    {
        [Key]
        public int Id { get; set; }
        public int IdPedido { get; set; }
        [ForeignKey(nameof(IdPedido))]
        public Pedido Pedido { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(20, ErrorMessage = "El campo debe tener un maximo 20", MinimumLength = 2)]
        public string Metodo_Pago { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(20, ErrorMessage = "El campo debe tener un maximo 20", MinimumLength = 5)]
        public string Estado { get; set; }
        [Required(ErrorMessage = "La fecha es requerida")]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }
    }
}
