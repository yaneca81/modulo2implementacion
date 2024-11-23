using Microsoft.EntityFrameworkCore;
using Practica2.Models;
using System.Collections.Generic;
using System.Reflection.Emit;
namespace Practica2.Data
{
    public class DataConection : DbContext
    {
        public DataConection(DbContextOptions<DataConection> options)
            : base(options)
        {
        }

        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Enfermero> Enfermeros { get; set; }
        public DbSet<Cita> CitasMedicas { get; set; }
        public DbSet<Hospitalizacion> Hospitalizaciones { get; set; }
        public DbSet<Expediente> ExpedientesMedicos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración específica para ExpedienteMedico (relación uno a uno con Paciente)
            modelBuilder.Entity<Expediente>()
                .HasOne(e => e.Paciente)
                .WithOne(p => p.Expediente)
                .HasForeignKey<Expediente>(e => e.PacienteId);
        }
    }
}
