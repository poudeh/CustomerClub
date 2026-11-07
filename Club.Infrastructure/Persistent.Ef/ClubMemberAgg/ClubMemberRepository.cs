using Club.Domain.ClubMemberAgg;
using Club.Domain.ClubMemberAgg.Repository;
using Club.Domain.CustomerAgg;
using Club.Infrastructure._Utilities;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure._Utilities;

namespace Club.Infrastructure.Persistent.Ef.ClubMemberAgg;

public class ClubMemberRepository : BaseRepository<ClubMember>, IClubMemberRepository
{
    public ClubMemberRepository(ClubContext context) : base(context)
    {
    }

    public async Task<ClubMember?> GetClubMemberByCustomer(long customerId)
    {
        return await Context.Set<ClubMember>()
            .FirstOrDefaultAsync(x => x.CustomerId == customerId);
    }
}
