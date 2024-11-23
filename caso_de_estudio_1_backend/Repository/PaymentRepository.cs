using caso_de_estudio_1_backend.Data;
using caso_de_estudio_1_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace caso_de_estudio_1_backend.Repository
{
    public class PaymentRepository : ICommonRepository<Payment>
    {
        private readonly AppDbContext _context;

        public PaymentRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Payment>> Get()
        {
            var payments = await _context.Payments.ToListAsync();
            return payments;
        }

        public async Task<Payment> GetById(int id)
        {
            var payment = await _context.Payments.FindAsync(id);
            return payment;
        }

        public async Task Add(Payment entity)
        {
            await _context.Payments.AddAsync(entity);
        }
        public void Update(Payment entity)
        {
            _context.Payments.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(Payment entity)
        {
            _context.Payments.Remove(entity);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
