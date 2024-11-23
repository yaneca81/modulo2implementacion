using Api_Centro_de_Salud.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_Centro_de_Salud.Data
{
    public class ConexionDB: DbContext
    {
        public ConexionDB(DbContextOptions<ConexionDB>options):base(options) { }

        public DbSet<Cita> Cita { get; set; }
        public DbSet<Enfermero> Enfermero { get; set;}
        public DbSet<ExpedienteMedico> ExpedienteMedico { get; set; }
        public DbSet<Hospitalizacion> Hospitalizacion { get; set; }
        public DbSet<Medico> Medico { get; set; }
        public DbSet<Notificacion> Notificacion { get; set;}
        public DbSet<Paciente> Paciente { get; set;}
    }
}
