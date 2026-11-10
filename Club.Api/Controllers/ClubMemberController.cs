using Club.Api.Infrastructure.Security;
using Club.Application.ClubMembers.ChangeClubMemberStatus;
using Club.Application.ClubMembers.Create;
using Club.Application.ClubMembers.Edit;
using Club.Domain.RoleAgg.Enums;
using Common.AspNetCore;
using Common.Common.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace Club.Api.Controllers;

[PermissionChecker(Permission.ClubMember_Management)]
public class ClubMemberController : ApiController
{
    private readonly IMediator _mediator;

    public ClubMemberController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ApiResult> CreateClubMember(CreateClubMemberCommand command)
    {
        var result = await _mediator.Send(command);
        return CommandResult(result);
    }

    [HttpPut]
    public async Task<ApiResult> EditClubMember(EditClubMemberCommand command)
    {
        var result = await _mediator.Send(command);
        return CommandResult(result);
    }

    [HttpPut]
    public async Task<ApiResult> ChangeClubMemberStatus(ChangeClubMemberStatusCommand command)
    {
        var result = await _mediator.Send(command);
        return CommandResult(result);
    }
}

