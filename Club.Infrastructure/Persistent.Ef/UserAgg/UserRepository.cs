using Club.Domain.UserAgg;
using Club.Domain.UserAgg.Repository;
using Club.Infrastructure._Utilities;

namespace Club.Infrastructure.Persistent.Ef.UserAgg;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(ClubContext context) : base(context)
    {
    }
}
