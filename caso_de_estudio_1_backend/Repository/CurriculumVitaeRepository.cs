using caso_de_estudio_1_backend.Data;
using caso_de_estudio_1_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace caso_de_estudio_1_backend.Repository
{
    public class CurriculumVitaeRepository : ICommonRepository<CurriculumVitae>
    {
        private readonly AppDbContext _context;
        public CurriculumVitaeRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<CurriculumVitae>> Get()
        {
            var curriculumVitae = await _context.CurriculumVitaes.ToListAsync();
            return curriculumVitae;
        }

        public async Task<CurriculumVitae> GetById(int id)
        {
            var curriculumVitae = await _context.CurriculumVitaes.FindAsync(id);
            return curriculumVitae;
        }

        public async Task Add(CurriculumVitae entity)
        {
            await _context.CurriculumVitaes.AddAsync(entity);
        }
        public void Update(CurriculumVitae entity)
        {
            _context.CurriculumVitaes.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(CurriculumVitae entity)
        {
            _context.CurriculumVitaes.Remove(entity);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
