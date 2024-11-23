using Actividad2_API_A2.Models;
using Microsoft.EntityFrameworkCore;

namespace Actividad2_API_A2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Asociado> Asociados { get; set; }
        public DbSet<CurriculumVitae> CurriculumVitaes { get; set; }
        public DbSet<Cuota> Cuotas { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<OfertaLaboral> OfertasLaborales { get; set; }
        public DbSet<Propuesta> Propuestas { get; set; }
    }
}
