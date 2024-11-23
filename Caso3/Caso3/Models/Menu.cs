using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Caso3.Models
{
    public class Menu
    {
        [Key]
        public int MenuId { get; set; }

        [Required]
        public int RestauranteId { get; set; }

        [ForeignKey("RestauranteId")]
        public Restaurante Restaurante { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Precio { get; set; }

        [StringLength(200)]
        public string ImagenUrl { get; set; }
    }
}
