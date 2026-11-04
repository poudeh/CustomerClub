using Club.Domain.ClubMemberAgg;
using Club.Domain.ClubMemberAgg.Repository;
using Shop.Infrastructure._Utilities;

namespace Club.Infrastructure.Persistent.Ef.ClubMemberAgg;

public class ClubMemberRepository : BaseRepository<ClubMember>, IClubMemberRepository
{
    public ClubMemberRepository(ClubContext context) : base(context)
    {
    }
}
