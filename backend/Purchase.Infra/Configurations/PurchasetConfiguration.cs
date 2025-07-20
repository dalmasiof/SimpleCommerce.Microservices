using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Purchase.Infra.Configurations
{

    public class PurchaseConfiguration : IEntityTypeConfiguration<Domain.Entities.Purchase>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Purchase> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                   .IsRequired();

            builder.Property(p => p.CustomerId)
                   .IsRequired();

            builder.Property(p => p.ProductId)
                   .IsRequired();

            builder.Property(p => p.Quantity)
                   .IsRequired();

            builder.Property(p => p.UnitPrice)
                   .IsRequired();

            builder.Property(p => p.TotalPrice)
                .IsRequired();

            // Indexes are optional in this case. Can improve queries
            builder.HasIndex(p => p.CustomerId);
            builder.HasIndex(p => p.ProductId);
        }
    }
}
