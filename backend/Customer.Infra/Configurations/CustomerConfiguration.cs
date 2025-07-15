using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Customer.Infra.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Domain.Entities.Customer>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Customer> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(c => c.FullName)
           .HasMaxLength(100)
           .IsRequired();

            builder.Property(c => c.Email)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
