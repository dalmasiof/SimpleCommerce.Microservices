using Customer.Infra.Context;
using Customer.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

public class CustomerRepository : ICustomerRepository
{
    private readonly CustomerDbContext _context;

    public CustomerRepository(CustomerDbContext context)
    {
        _context = context;
    }


    public async Task<Customer.Domain.Entities.Customer> Create(Customer.Domain.Entities.Customer entity)
    {
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> Delete(Guid id)
    {
        var entity = await _context.Customers.Where(x=>x.Id == id).FirstOrDefaultAsync();
        if (entity == null) return false;

        _context.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<IList<Customer.Domain.Entities.Customer>> GetAll()
    {
        return await _context.Customers.AsNoTracking().ToListAsync();
    }

    public async Task<Customer.Domain.Entities.Customer> GetById(Guid id)
    {
        return await _context.Customers.Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task<Customer.Domain.Entities.Customer> Update(Customer.Domain.Entities.Customer entity)
    {
        _context.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}
