using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practica2_Mod.Models
{
 public class Nomina
 {
  [Key]
  public int Id { get; set; }
  [Required(ErrorMessage = "El campo es obligatorio")]
  public int Sueldo_Base { get; set; }
  [Required(ErrorMessage = "El campo es obligatorio")]
  public DateTime Fecha_Ingreso { get; set; }
  [Required(ErrorMessage = "El campo es obligatorio")]
  public string Horario_Asignado { get; set; }
  [Required(ErrorMessage = "El campo es obligatorio")]
  public int Dias_Trabajados { get; set; }
  [Required(ErrorMessage = "El campo es obligatorio")]
  public int Pagos_extras { get; set; }
  [Required(ErrorMessage = "El campo es obligatorio")]
  public int Permisos {  get; set; }
  [Required(ErrorMessage = "El campo es obligatorio")]
  public int Total_Descuentos { get; set; }
  [Required(ErrorMessage = "El campo es obligatorio")]
  public int Sueldo_total { get; set; }
  public int IdEmpleado { get; set; }
  [ForeignKey(nameof(IdEmpleado))]
  public Empleado Empleado { get; set; }

 }
}
