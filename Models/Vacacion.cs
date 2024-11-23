using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practica2_Mod.Models
{
 public class Vacacion
 {
  [Key]
  public int Id { get; set; }
  [Required(ErrorMessage = "El campo es obligatorio")]
  public DateTime Fecha_Inicio { get; set; }
  [Required(ErrorMessage = "El campo es obligatorio")]
  public DateTime Fecha_Culminacion { get; set; }
  [Required(ErrorMessage = "El campo es obligatorio")]
  public string Estado {  get; set; }
  public int IdEmpleado { get; set; }
  [ForeignKey(nameof(IdEmpleado))]
  public Empleado Empleado { get; set; }
 }
}
