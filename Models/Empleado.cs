using System.ComponentModel.DataAnnotations;

namespace Practica2_Mod.Models
{
 public class Empleado
 {
  [Key]
  public int Id { get; set; }
  [Required(ErrorMessage = "El campo es obligatorio")]
  public string Nombre { get; set; }
  [Required(ErrorMessage = "El campo es obligatorio")]
  public string Apellido { get; set; }
  [Required(ErrorMessage = "El campo es obligatorio")]
  public int Ci {  get; set; }
  [Required(ErrorMessage = "El campo es obligatorio")]
  public string Cargo { get; set; }
  [Required(ErrorMessage = "El campo es obligatorio")]
  public string Direccion { get; set;}
  [Required(ErrorMessage = "El campo es obligatorio")]
  public int Telefono { get; set;}
  [Required(ErrorMessage = "El campo es obligatorio")]
  public string Estado { get; set; }

  
 }
}
