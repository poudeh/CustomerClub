using Club.Application.Roles.Create;
using Club.Application.Roles.Edit;
using Club.Queries.Roles.DTOs;
using Club.Queries.Roles.GetById;
using Club.Queries.Roles.GetList;
using Common.Application;
using Common.AspNetCore;
using Common.Common.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace Club.Api.Controllers;

public class RoleController : ApiController
{
    private readonly IMediator _mediator;
    public RoleController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ApiResult<List<RoleDto>>> GetRoles()
    {
        var result = await _mediator.Send(new GetRoleListQuery());
        return QueryResult(result);
    }

    [HttpPost]
    public async Task<ApiResult> CreateRole(CreateRoleCommand command)
    {
        var result = await _mediator.Send(command);
        return CommandResult(result);
    }

    [HttpPut]
    public async Task<OperationResult> EditRole(EditRoleCommand command)
    {
        return await _mediator.Send(command);
    }
    [HttpGet]
    public async Task<RoleDto?> GetRoleById([FromQuery]long roleId)
    {
        return await _mediator.Send(new GetRoleByIdQuery(roleId));
    }

}

