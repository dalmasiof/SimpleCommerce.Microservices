using Customer.Domain.Interfaces;
using Customer.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Customer.Infra.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerDbContext _context;

        public CustomerRepository(CustomerDbContext context)
        {
            _context = context;
        }

        public async Task<Domain.Entities.Customer>Create(Domain.Entities.Customer entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Domain.Entities.Customer> Get(Guid guid)
        {
            return await _context.Customers.Where(x=>x.Id == guid).FirstOrDefaultAsync();
        }

        public async Task<IList<Domain.Entities.Customer>> Get()
        {
            return await _context.Customers.ToListAsync();
        }
    }
}
