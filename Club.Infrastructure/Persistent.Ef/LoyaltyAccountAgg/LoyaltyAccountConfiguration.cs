using Club.Domain.ClubMemberAgg;
using Club.Domain.LoyaltyAccountAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Club.Infrastructure.Persistent.Ef.LoyaltyAccountAgg;

public class LoyaltyAccountConfiguration : IEntityTypeConfiguration<LoyaltyAccount>
{
    public void Configure(EntityTypeBuilder<LoyaltyAccount> builder)
    {
        builder.ToTable("LoyaltyAccounts");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.ClubMemberId)
            .IsRequired();

        builder.HasIndex(x => x.ClubMemberId)
            .IsUnique();

        builder.Property(x => x.Balance)
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(x => x.TotalEarnedPoints)
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(x => x.TotalSpentPoints)
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(x => x.Status)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(x => x.LastUpdatedAt)
            .IsRequired(false);

        builder.HasOne(x=> x.ClubMember)
            .WithOne(x=>x.LoyaltyAccount )
            .HasForeignKey<LoyaltyAccount>(x => x.ClubMemberId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}