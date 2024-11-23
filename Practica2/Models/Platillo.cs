using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practica2.Models
{
    public class Platillo
    {
        [Key]
        public int Id { get; set; }
        public int IdMenu { get; set; }
        [ForeignKey(nameof(IdMenu))]
        public Menu Menu { get; set; }
        
        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(20, ErrorMessage = "El campo debe tener un maximo 20 y un minimo de ", MinimumLength = 5)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(20, ErrorMessage = "El campo debe tener un maximo 20 y un minimo de ", MinimumLength = 5)]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        [Range(20, 200)]
        public int Precio { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        public int Cantidad { get; set; }

        //public ICollection<Detalle_Pedido> Detalle_Pedidos { get; set; }
    }
}
