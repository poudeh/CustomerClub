using Club.Domain.ClubMemberAgg;
using Club.Domain.CustomerAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Club.Infrastructure.Persistent.Ef.ClubMemberAgg;

public class ClubMemberConfiguration : IEntityTypeConfiguration<ClubMember>
{
    public void Configure(EntityTypeBuilder<ClubMember> builder)
    {
        builder.ToTable("ClubMembers");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.MemberCode)
            .IsRequired()
            .HasMaxLength(50);

        builder.HasIndex(x => x.MemberCode)
            .IsUnique();

        builder.Property(x => x.CustomerId)
            .IsRequired();

        builder.HasIndex(x => x.CustomerId)
            .IsUnique();

        builder.Property(x => x.Status)
            .IsRequired()
            .HasConversion<int>();

        builder.HasOne(x=> x.Customer)
            .WithOne(x=> x.ClubMember)
            .HasForeignKey<ClubMember>(x => x.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
