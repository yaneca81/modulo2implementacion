using System.ComponentModel.DataAnnotations;

namespace Practica2_Mod.Models
{
 public class Capacitacion
 {
  [Key]
  public int Id { get; set; }
  [Required(ErrorMessage = "El campo es obligatorio")]
  public string Titulo { get; set; }
  [Required(ErrorMessage = "El campo es obligatorio")]
  public string Descripcion { get; set; }
  [Required(ErrorMessage = "El campo es obligatorio")]
  public string Tipo { get; set; }
  [Required(ErrorMessage = "El campo es obligatorio")]
  public int Duracion { get; set; }
  [Required(ErrorMessage = "El campo es obligatorio")]
  public DateTime Fecha_Inicio { get; set; }
  [Required(ErrorMessage = "El campo es obligatorio")]
  public DateTime Fecha_Culminacion { get; set; }
  [Required(ErrorMessage = "El campo es obligatorio")]
  public string Estado { get; set; }

 }
}
