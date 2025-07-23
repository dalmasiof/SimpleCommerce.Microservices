using Microsoft.EntityFrameworkCore;
using Purchase.Infra.Context;
using Purchase.Infra.Interfaces;

namespace Purchase.Infra.Repositories
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly PurchaseContext _context;

        public PurchaseRepository(PurchaseContext context)
        {
            _context = context;
        }

        public async Task<Domain.Entities.Purchase> Create(Domain.Entities.Purchase entity)
        {
            await _context.Purchases.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _context.Purchases.FirstOrDefaultAsync(p => p.Id == id);
            if (entity == null) return false;

            _context.Purchases.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IList<Domain.Entities.Purchase>> GetAll()
        {
            return await _context.Purchases.AsNoTracking().ToListAsync();
        }

        public async Task<Domain.Entities.Purchase> GetById(Guid id)
        {
            return await _context.Purchases.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Domain.Entities.Purchase> Update(Domain.Entities.Purchase entity)
        {
            _context.Purchases.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
