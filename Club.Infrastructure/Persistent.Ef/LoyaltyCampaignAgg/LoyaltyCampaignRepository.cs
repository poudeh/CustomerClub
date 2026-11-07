using Club.Domain.LoyaltyCampaignAgg;
using Club.Domain.LoyaltyCampaignAgg.Repository;
using Club.Infrastructure._Utilities;

namespace Club.Infrastructure.Persistent.Ef.LoyaltyCampaignAgg;

public class LoyaltyCampaignRepository : BaseRepository<LoyaltyCampaign> , ILoyaltyCampaignRepository
{
    public LoyaltyCampaignRepository(ClubContext context) : base(context)
    {
    }
}