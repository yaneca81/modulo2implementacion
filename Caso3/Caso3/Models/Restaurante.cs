using System.ComponentModel.DataAnnotations;

namespace Caso3.Models
{
    public class Restaurante
    {
        [Key]
        public int RestauranteId { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(200)]
        public string Direccion { get; set; }

        [StringLength(15)]
        public string Telefono { get; set; }

        [Required]
        [StringLength(150)]
        [EmailAddress]
        public string Correo { get; set; }

        // Relación con Menu
        public ICollection<Menu> Menus { get; set; }

        // Relación con Pedido
        public ICollection<Pedido> Pedidos { get; set; }
    }
}
