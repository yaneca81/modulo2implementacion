using System.ComponentModel.DataAnnotations;

namespace Caso3.Models
{
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(150)]
        [EmailAddress]
        public string Correo { get; set; }

        [Required]
        [StringLength(255)]
        public string Contraseña { get; set; }

        [StringLength(15)]
        public string Telefono { get; set; }

        // Relación con Pedido
        public ICollection<Pedido> Pedidos { get; set; }
    }
}
