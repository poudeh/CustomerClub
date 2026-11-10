using Club.Domain.RoleAgg;
using Club.Domain.UserAgg;
using Club.Infrastructure.Persistent.Ef;
using Club.Queries.Users.DTOs;
using Microsoft.EntityFrameworkCore;
namespace Club.Queries.Users;

public static class UserMapper
{
    public static UserDto Map(this User user)
    {
        return new UserDto()
        {
            Id = user.Id,
            Username = user.Username,
            CreationDate = user.CreationDate,
            PasswordHash = user.PasswordHash,
            IsActive = user.IsActive,
            Roles = user.Roles.Select(s => new UserRoleDto()
            {
                RoleId = s.RoleId,
                RoleTitle = ""
            }).ToList()
        };
    }

    public static async Task<UserDto> SetUserRoleTitles(this UserDto userDto, ClubContext context)
    {
        IEnumerable<long> roleIds = userDto.Roles.Select(r => r.RoleId);
        List<Role> result = await context.Roles.Where(r => roleIds.Contains(r.Id)).ToListAsync();
        var roles = new List<UserRoleDto>();
        foreach (var role in result)
        {
            roles.Add(new UserRoleDto()
            {
                RoleId = role.Id,
                RoleTitle = role.Title
            });
        }

        userDto.Roles = roles;
        return userDto;
    }

    public static UserFilterData MapFilterData(this User user)
    {
        return new UserFilterData()
        {
            Id = user.Id,
            Username = user.Username,
            IsActive = user.IsActive,
            CreationDate = user.CreationDate,
            PhoneNumber = user.PhoneNumber,
            Gender = user.Gender,
        };
    }
}