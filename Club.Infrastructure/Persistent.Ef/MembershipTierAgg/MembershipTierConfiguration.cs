using Club.Domain.MembershipTierAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Club.Infrastructure.Persistent.Ef.MembershipTierAgg;

public class MembershipTierConfiguration : IEntityTypeConfiguration<MembershipTier>
{
    public void Configure(EntityTypeBuilder<MembershipTier> builder)
    {
        builder.ToTable("MembershipTiers");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.Type)
            .IsRequired()
            .HasConversion<int>();

        builder.HasMany(x => x.Requirements)
            .WithOne(x=> x.MembershipTier)
            .HasForeignKey(x => x.MembershipTierId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Navigation(x => x.Requirements)
            .UsePropertyAccessMode(PropertyAccessMode.Field);
    }
}
