using System.ComponentModel.DataAnnotations;

namespace Actividad2.Models
{
    public class Especialidad
    {
        [Key]//DataAnnotaciones como indicadores
        public int Id { get; set; }
        [Required(ErrorMessage = "EL campo Nombre Especialidad es requerido")]
        [StringLength(50, ErrorMessage = "El campo debe tener maximo 50 y minimo 5", MinimumLength = 5)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "EL campo Descripcion es requerido")]
        [StringLength(200, ErrorMessage = "El campo debe tener maximo 200 y minimo 10", MinimumLength = 10)]
        public string Descripcion { get; set; }
    }
}
