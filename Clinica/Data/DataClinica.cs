using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Clinia.Models;
using Clinica.Models;

namespace Clinia.Data
{
    public class DataClinica : DbContext
    {
        public DataClinica(DbContextOptions<DataClinica> options) : base(options) { }

        public DbSet<Cita> Citas { get; set; }
        public DbSet<Historial_clinico> Historial_Clinicos { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Tratamiento> Tratamientos { get; set; }
        public DbSet<VideoLlamada> VideoLlamadas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Cita>()
                .HasOne(c => c.Paciente)
                .WithMany()  
                .HasForeignKey(c => c.IdPaciente)
                .OnDelete(DeleteBehavior.NoAction);  

            modelBuilder.Entity<Cita>()
                .HasOne(c => c.Medico)
                .WithMany()  
                .HasForeignKey(c => c.IdMedico)
                .OnDelete(DeleteBehavior.NoAction); 

            modelBuilder.Entity<VideoLlamada>()
                .HasOne(v => v.Medico)
                .WithMany()  
                .HasForeignKey(v => v.IdMedico)
                .OnDelete(DeleteBehavior.NoAction); 

            modelBuilder.Entity<VideoLlamada>()
                .HasOne(v => v.Paciente)
                .WithMany()  
                .HasForeignKey(v => v.IdPaciente)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Tratamiento>()
               .HasOne(t => t.Paciente)
               .WithMany()  
               .HasForeignKey(t => t.IdPaciente)
               .OnDelete(DeleteBehavior.NoAction);  

            modelBuilder.Entity<Tratamiento>()
                .HasOne(t => t.Medico)
                .WithMany()  
                .HasForeignKey(t => t.IdMedico)
                .OnDelete(DeleteBehavior.NoAction); 

            modelBuilder.Entity<Tratamiento>()
                .HasOne(t => t.Historial_Clinico)
                .WithMany() 
                .HasForeignKey(t => t.IdHistorialClinico)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
