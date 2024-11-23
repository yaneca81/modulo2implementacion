using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practica2_Mod.Models
{
 public class Capacitacion_Empleado
 {
  [Key]
  public int Id { get; set; }
  public int IdCapacitacion { get; set; }
  [ForeignKey(nameof(IdCapacitacion))]
  public Capacitacion Capacitacion { get; set; }
  public int IdEmpleado { get; set; }
  [ForeignKey(nameof(IdEmpleado))]
  public Empleado Empleado { get; set;}

 }
}
