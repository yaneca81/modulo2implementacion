using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Actividad2.Models;

namespace Actividad2.Data
{
    public class DataPractica : DbContext
    {
        public DataPractica(DbContextOptions<DataPractica> options) : base(options) { }
        public DbSet<Cita> Citas { get; set; }
        public DbSet<Doctor> Doctores { get; set; }
        public DbSet<Especialidad> Especialidades { get; set; }
        public DbSet<Historial> Historiales { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<SesionVideoLlamada> SesionVideoLlamadas { get; set; }
        public DbSet<Tratamiento> Tratamientos { get; set; }
    }
}
