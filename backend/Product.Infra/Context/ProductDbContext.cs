using Microsoft.EntityFrameworkCore;
using Product.Infra.Configurations;

namespace Product.Infra.Context
{
    public  class ProductDbContext : DbContext
    {
        public DbSet<Product.Domain.Entities.Product> Products { get; set; }

        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }
    }
}
