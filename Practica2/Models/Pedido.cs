using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practica2.Models
{
    public class Pedido
    {
        [Key]
        public int Id { get; set; }
        //public ICollection<Detalle_Pedido> Detalle_Pedidos { get; set; }
        public int IdUsuario { get; set; }
        [ForeignKey(nameof(IdUsuario))]
        public Usuario Usuario { get; set; }
        public int IdRestaurante { get; set; }
        [ForeignKey(nameof(IdRestaurante))]
        public Restaurante Restaurante { get; set; }
        


        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(20, ErrorMessage = "El campo debe tener un maximo 20 y un minimo de ", MinimumLength = 5)]
        public string Estado { get; set; }
        [Required(ErrorMessage = "El Monto es requerido")]
        [Range(20, 1000)]
        public int Total { get; set; }
        [Required(ErrorMessage = "La fecha es requerida")]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }
    }
}
