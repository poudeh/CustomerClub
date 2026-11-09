using Club.Infrastructure.Persistent.Ef;
using Club.Queries.Roles.DTOs;
using Common.Common.Query;
using Common.Query;
using Microsoft.EntityFrameworkCore;

namespace Club.Queries.Roles.GetList;

public class GetRoleListQueryHandler(ClubContext context) : IQueryHandler<GetRoleListQuery, List<RoleDto>>
{
    public async Task<List<RoleDto>> Handle(GetRoleListQuery request, CancellationToken cancellationToken)
    {
        return await context.Roles.Select(role => new RoleDto()
        {
            Id = role.Id,
            CreationDate = role.CreationDate,
            Permissions = role.Permissions.Select(s => s.Permission).ToList(),
            Title = role.Title
        }).ToListAsync(cancellationToken);
    }
}