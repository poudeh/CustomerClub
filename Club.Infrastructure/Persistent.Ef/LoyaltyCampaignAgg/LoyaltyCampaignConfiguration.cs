using Club.Domain.LoyaltyCampaignAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Club.Infrastructure.Persistent.Ef.LoyaltyCampaignAgg;

public class LoyaltyCampaignConfiguration:IEntityTypeConfiguration<LoyaltyCampaign>
{
    public void Configure(EntityTypeBuilder<LoyaltyCampaign> builder)
    {
        builder.ToTable("LoyaltyCampaigns");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.Message)
            .IsRequired()
            .HasMaxLength(1000);

        builder.Property(x => x.Status)
            .IsRequired()
            .HasConversion<int>();

        builder.Property(x => x.SentAt)
            .IsRequired(false);

        builder.HasMany(x => x.Recipients)
            .WithOne(x=> x.LoyaltyCampaign)
            .HasForeignKey(x => x.LoyalCampaignId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Navigation(x => x.Recipients)
            .UsePropertyAccessMode(PropertyAccessMode.Field);
    }
}