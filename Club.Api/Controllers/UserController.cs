using Club.Api.Infrastructure.Security;
using Club.Application.Users.AddRole;
using Club.Application.Users.AdminChangePassword;
using Club.Application.Users.ClearRoles;
using Club.Application.Users.Create;
using Club.Application.Users.Edit;
using Club.Application.Users.RemoveCustomer;
using Club.Application.Users.RemoveRole;
using Club.Application.Users.ToggleActivation;
using Club.Domain.RoleAgg.Enums;
using Club.Queries.Users.DTOs;
using Club.Queries.Users.GetByFilter;
using Common.AspNetCore;
using Common.Common.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace Club.Api.Controllers;

[Authorize]
public class UserController : ApiController
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [PermissionChecker(Permission.User_Management)]
    [HttpGet]
    public async Task<ApiResult<UserFilterResult>> GetUsers([FromQuery] UserFilterParams filterParams)
    {
        var result = await _mediator.Send(new GetUserByFilterQuery(filterParams));
        return QueryResult(result);
    }

    [HttpPost]
    public async Task<ApiResult> CreateUser(CreateUserCommand command)
    {
        var result = await _mediator.Send(command);
        return CommandResult(result);
    }

    [HttpPut]
    public async Task<ApiResult> EditUser(EditUserCommand command)
    {
        var result = await _mediator.Send(command);
        return CommandResult(result);
    }

    [HttpPost]
    public async Task<ApiResult> AddRole(AddUserRoleCommand command)
    {
        var result = await _mediator.Send(command);
        return CommandResult(result);
    }

    [HttpDelete]
    public async Task<ApiResult> RemoveRole(RemoveUserRoleCommand command)
    {
        var result = await _mediator.Send(command);
        return CommandResult(result);
    }

    [HttpPut]
    public async Task<ApiResult> ToggleActivation(ToggleUserActivationCommand command)
    {
        var result = await _mediator.Send(command);
        return CommandResult(result);
    }

    [HttpPut]
    public async Task<ApiResult> ChangePassword(ChangeUserPasswordCommand command)
    {
        var result = await _mediator.Send(command);
        return CommandResult(result);
    }

    [HttpPut]
    public async Task<ApiResult> RemoveCustomer(RemoveUserCustomerCommand command)
    {
        var result = await _mediator.Send(command);
        return CommandResult(result);
    }

    [HttpPut]
    public async Task<ApiResult> ClearRoles(ClearUserRolesCommand command)
    {
        var result = await _mediator.Send(command);
        return CommandResult(result);
    }
}

