using Club.Domain.ClubMemberAgg.Repository;
using Common.Application;
namespace Club.Application.ClubMembers.ChangeClubMemberStatus;

public class ChangeClubMemberStatusCommandHandler(IClubMemberRepository repository) : IBaseCommandHandler<ChangeClubMemberStatusCommand>
{
    public async Task<OperationResult> Handle(ChangeClubMemberStatusCommand request, CancellationToken cancellationToken)
    {
        var clubMember = await repository.GetTracking(request.ClubMemberId);
        if (clubMember == null)
            return OperationResult.NotFound();
        clubMember.ChangeStatus(request.Status);
        await repository.Save();
        return OperationResult.Success();
    }
}