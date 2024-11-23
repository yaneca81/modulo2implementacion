using Microsoft.EntityFrameworkCore;
using TeleMedicina.Models;

namespace TeleMedicina.Data
{
    public class DataTelemedicina : DbContext
    {
        public DataTelemedicina(DbContextOptions<DataTelemedicina> options) : base(options)
        {
        }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Cita> Citas { get; set; }
        public DbSet<HistorialMedico> HistorialesMedicos { get; set; }
        public DbSet<Tratamiento> Tratamientos { get; set; }

       
    }

}
