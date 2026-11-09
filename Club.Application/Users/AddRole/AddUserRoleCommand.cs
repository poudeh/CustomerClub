using Common.Application;

namespace Club.Application.Users.AddRole;

public record AddUserRoleCommand(long UserId, long RoleId) : IBaseCommand;
