using Club.Domain.RoleAgg.Enums;
using Common.Query;

namespace Club.Queries.Roles.DTOs;

public class RoleDto : BaseDto
{
    public string Title { get; set; }
    public List<Permission> Permissions { get; set; }
}