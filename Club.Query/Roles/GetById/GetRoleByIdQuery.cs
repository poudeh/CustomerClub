using Club.Query.Roles.DTOs;
using Common.Query;

namespace Club.Query.Roles.GetById;

public record GetRoleByIdQuery(long RoleId) : IQuery<RoleDto?>;