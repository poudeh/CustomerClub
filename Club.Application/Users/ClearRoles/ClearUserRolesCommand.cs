using Common.Application;

namespace Club.Application.Users.ClearRoles;

public record ClearUserRolesCommand(long Id) : IBaseCommand;
