using Club.Domain.RoleAgg.Enums;
using Club.Queries.Roles.GetList;
using Club.Queries.Users.GetById;
using Common.Common.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
namespace Club.Api.Infrastructure.Security;

public class PermissionChecker : AuthorizeAttribute, IAsyncAuthorizationFilter
{
    private readonly Permission _permission;

    public PermissionChecker(Permission permission)
    {
        _permission = permission;
    }

    public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    {
        if (HasAllowAnonymous(context))
            return;

        var mediator = context.HttpContext.RequestServices.GetRequiredService<IMediator>();
        if (context.HttpContext.User.Identity?.IsAuthenticated == true)
        {
            if (await UserHasPermission(context, mediator) == false)
                context.Result = new ForbidResult();
            
        }
        else context.Result = new UnauthorizedObjectResult("Unauthorized");
    }

    private bool HasAllowAnonymous(AuthorizationFilterContext context)
    {
        return context.ActionDescriptor.EndpointMetadata.OfType<IAllowAnonymous>()
            .Any();
    }

    private async Task<bool> UserHasPermission(AuthorizationFilterContext context, IMediator mediator)
    {
        var userId = context.HttpContext.User.GetUserId();
        var user = await mediator.Send(new GetUserByIdQuery(userId));
        if (user == null)
            return false;
        var roleIds = user.Roles.Select(s => s.RoleId).ToList();
        var roles = await mediator.Send(new GetRoleListQuery());
        var userRoles = roles.Where(r => roleIds.Contains(r.Id));
        return userRoles.Any(r => r.Permissions.Contains(_permission));
    }
}