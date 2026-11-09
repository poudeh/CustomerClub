using Club.Domain.LoyaltyAccountAgg;
using Club.Domain.LoyaltyAccountAgg.Repository;
using Club.Infrastructure._Utilities;

namespace Club.Infrastructure.Persistent.Ef.LoyaltyAccountAgg;

public class LoyaltyAccountRepository : BaseRepository<LoyaltyAccount> , ILoyaltyAccountRepository
{
    public LoyaltyAccountRepository(ClubContext context) : base(context)
    {
    }
}