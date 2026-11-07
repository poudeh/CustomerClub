using Club.Domain.RoleAgg.Enums;
using Common.Common.Domain;
using Common.Domain;

namespace Club.Domain.RoleAgg;

public class RolePermission:BaseEntity
{
    public RolePermission(Permission permission)
    {
        Permission = permission;
    }

    public long RoleId { get; internal set; }
    public Permission Permission { get; private set; }
    public virtual Role Role { get; set; }
}
