using Common.Query;

namespace Club.Queries.Users.DTOs;

public class UserDto:BaseDto
{
    public string Username { get; set; }
    public string PhoneNumber { get; set; }
    public string PasswordHash { get; set; }
    public string Email { get; set; }
    public bool IsActive { get;  set; }
    public List<UserRoleDto> Roles { get; set; } = [];

}

public class UserRoleDto
{
    public long RoleId { get; set; }
    public string RoleTitle { get; set; }
}

