using Club.Domain.RoleAgg;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Common.Common.Domain;

namespace Club.Domain.UserAgg.Entities;

public class UserRole:BaseEntity
{
    public UserRole(long roleId)
    {
        RoleId = roleId;
    }

    public long UserId { get;  set; }
    public long RoleId { get;  set; }
    public User User { get;  set; }
    public Role Role { get;  set; }
}
