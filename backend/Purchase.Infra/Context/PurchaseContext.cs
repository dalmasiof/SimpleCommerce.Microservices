using Microsoft.EntityFrameworkCore;
using Purchase.Infra.Configurations;

namespace Purchase.Infra.Context
{
    public class PurchaseContext : DbContext
    {
        public DbSet<Domain.Entities.Purchase> Purchases { get; set; }

        public PurchaseContext(DbContextOptions<PurchaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PurchaseConfiguration());
        }
    }
}
