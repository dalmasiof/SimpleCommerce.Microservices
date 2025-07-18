using Microsoft.EntityFrameworkCore;
using Product.Infra.Context;
using Product.Infra.Interfaces;

namespace Product.Infra.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _context;

        public ProductRepository(ProductDbContext context)
        {
            _context = context;
        }

        public async Task<Product.Domain.Entities.Product> Create(Product.Domain.Entities.Product entity)
        {
            await _context.Products.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (entity == null) return false;

            _context.Products.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IList<Product.Domain.Entities.Product>> GetAll()
        {
            return await _context.Products.AsNoTracking().ToListAsync();
        }

        public async Task<Product.Domain.Entities.Product> GetById(Guid id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Product.Domain.Entities.Product> Update(Product.Domain.Entities.Product entity)
        {
            _context.Products.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
