using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practica2.Models
{
    public class Menu
    {
        [Key]
        public int Id { get; set; }
        public int IdRestaurante { get; set; }
        [ForeignKey(nameof(IdRestaurante))]
        public Restaurante Restaurante { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(20, ErrorMessage = "El campo debe tener un maximo 20 y un minimo de ", MinimumLength = 5)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(20, ErrorMessage = "El campo debe tener un maximo 20 y un minimo de ", MinimumLength = 5)]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "El estado es requerido")]
        [StringLength(20, ErrorMessage = "El campo debe tener un maximo 20 y un minimo de ", MinimumLength = 5)]
        public string Estado { get; set; }
    }
}
