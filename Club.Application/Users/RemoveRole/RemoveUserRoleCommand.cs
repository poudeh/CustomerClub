using Common.Application;

namespace Club.Application.Users.RemoveRole;

public record RemoveUserRoleCommand(long UserId, long RoleId) : IBaseCommand;
