using Microsoft.EntityFrameworkCore;
using SistemaRecursosHumanos.Models;

namespace SistemaRecursosHumanos.Data
{
    public class DataPractica:DbContext
    {
        public DataPractica(DbContextOptions<DataPractica> options) : base(options) { }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Nomina> Nominas { get; set; }
        public DbSet<Capacitacion> Capacitaciones { get; set; }
        public DbSet<Reporte> Reportes { get; set; }

    }
}
