using Microsoft.EntityFrameworkCore;
using Practica2.Modelos;

namespace Practica2.Data
{
    public class DataPractica: DbContext
    {
        public DataPractica(DbContextOptions<DataPractica> options) : base(options) { }

        public DbSet<Cita> Citas { get; set; }
        public DbSet<Expediente> Expedientes { get; set; }
        public DbSet<Hospitalizacion> Hospitalizaciones { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }

    }
}
