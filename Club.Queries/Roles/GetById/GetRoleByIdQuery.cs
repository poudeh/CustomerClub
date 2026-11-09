using Club.Queries.Roles.DTOs;
using Common.Query;

namespace Club.Queries.Roles.GetById;

public record GetRoleByIdQuery(long RoleId) : IQuery<RoleDto?>;