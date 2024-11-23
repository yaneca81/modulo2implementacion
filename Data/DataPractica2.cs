using Microsoft.EntityFrameworkCore;
using Practica2_Mod.Models;

namespace Practica2_Mod.Data
{
 public class DataPractica2:DbContext
 {
  public DataPractica2(DbContextOptions<DataPractica2> options) : base(options) { }
  public DbSet<Empleado> Empleados { get; set; }
  public DbSet<Capacitacion> Capacitaciones { get; set; }
  public DbSet<Capacitacion_Empleado> Capacitaciones_Empleados { get; set; }
  public DbSet<Nomina> Nominas { get; set; }
  public DbSet<Permiso> Permisos { get; set; }
  public DbSet<Vacacion> Vacaciones { get; set; }






 }
}
