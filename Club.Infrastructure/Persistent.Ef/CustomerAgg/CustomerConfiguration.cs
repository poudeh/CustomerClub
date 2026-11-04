using Club.Domain.CustomerAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Club.Infrastructure.Persistent.Ef.CustomerAgg;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        // Table
        builder.ToTable("Customers");

        // Primary Key
        builder.HasKey(x => x.Id);

        // Name
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(200);

        // NationalId
        builder.Property(x => x.NationalId)
            .IsRequired()
            .HasMaxLength(20);

        // EconomicCode
        builder.Property(x => x.EconomicCode)
            .HasMaxLength(20);

        // PhoneNumber
        builder.Property(x => x.PhoneNumber)
            .HasMaxLength(20);

        // Email
        builder.Property(x => x.Email)
            .HasMaxLength(150);

        // Customer Type
        builder.Property(x => x.Type)
            .IsRequired()
            .HasConversion<int>();

        // IsActive
        builder.Property(x => x.IsActive)
            .IsRequired()
            .HasDefaultValue(true);

        // Unique Indexes
        builder.HasIndex(x => x.NationalId)
            .IsUnique();

        builder.HasIndex(x => x.EconomicCode)
            .IsUnique()
            .HasFilter("[EconomicCode] IS NOT NULL");
    }
}