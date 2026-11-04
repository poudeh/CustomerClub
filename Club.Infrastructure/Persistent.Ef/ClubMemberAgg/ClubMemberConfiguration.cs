using Club.Domain.ClubMemberAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

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

        builder.Property(x => x.JoinedAt)
            .IsRequired()
            .HasColumnType("datetime2");
    }
}
