using System.Security;
using Club.Domain.RoleAgg.Enums;
using Common.Application;

namespace Club.Application.Roles.Create;

public record CreateRoleCommand(string Title, List<Permission> Permissions):IBaseCommand;