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

        builder.OwnsMany(x => x.Requirements, requirement =>
        {
            requirement.ToTable("TierRequirements");

            requirement.WithOwner(x=> x.MembershipTier)
                .HasForeignKey(x=> x.MembershipTierId);

            requirement.HasKey(x=> x.Id);

            requirement.Property(x => x.Type)
                .IsRequired()
                .HasConversion<int>();

            requirement.Property(x => x.Operator)
                .IsRequired()
                .HasConversion<int>();

            requirement.Property(x => x.RequiredValue)
                .HasPrecision(18, 2);
        });

        builder.Navigation(x => x.Requirements)
            .UsePropertyAccessMode(PropertyAccessMode.Field);
    }
}
