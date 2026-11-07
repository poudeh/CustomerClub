using Club.Domain.RoleAgg;
using Club.Domain.RoleAgg.Repository;
using Club.Infrastructure._Utilities;

namespace Club.Infrastructure.Persistent.Ef.RoleAgg;

public class RoleRepository : BaseRepository<Role>, IRoleRepository
{
    public RoleRepository(ClubContext context) : base(context)
    {
    }
}
