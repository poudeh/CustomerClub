using Club.Domain.MembershipTierAgg;
using Club.Domain.MembershipTierAgg.Repository;
using Club.Infrastructure._Utilities;

namespace Club.Infrastructure.Persistent.Ef.MembershipTierAgg;

public class MembershipTierRepository : BaseRepository<MembershipTier>, IMembershipTierRepository
{
    public MembershipTierRepository(ClubContext context) : base(context)
    {
    }
}
