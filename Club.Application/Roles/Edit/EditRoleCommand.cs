using Club.Domain.RoleAgg.Enums;
using Common.Application;

namespace Club.Application.Roles.Edit;

public record EditRoleCommand(long Id, string Title, List<Permission> Permissions):IBaseCommand;