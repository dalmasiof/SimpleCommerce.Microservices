using Customer.Infra.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Customer.Infra.Context
{
    public class CustomerDbContext : DbContext
    {
        public DbSet<Customer.Domain.Entities.Customer> Customers { get; set; }

        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        }
    }
}
