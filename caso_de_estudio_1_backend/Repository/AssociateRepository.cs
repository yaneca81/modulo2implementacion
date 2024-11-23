using caso_de_estudio_1_backend.Data;
using caso_de_estudio_1_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace caso_de_estudio_1_backend.Repository
{
    public class AssociateRepository : ICommonRepository<Associate>
    {
        private readonly AppDbContext _context;
        public AssociateRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Associate>> Get()
        {
            var associates = await _context.Associates.ToListAsync();
            return associates;
        }

        public async Task<Associate> GetById(int id)
        {
            var associate = await _context.Associates.FindAsync(id);
            return associate;
        }

        public async Task Add(Associate entity)
        {
            await _context.Associates.AddAsync(entity);
        }
        public void Update(Associate entity)
        {
            _context.Associates.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(Associate entity)
        {
            _context.Associates.Remove(entity);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
