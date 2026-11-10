using Club.Domain.ClubMemberAgg.Repository;
using Common.Application;
using Common.Common.Application;

namespace Club.Application.ClubMembers.Edit;

public class EditClubMemberCommandHandler : IBaseCommandHandler<EditClubMemberCommand>
{
    private readonly IClubMemberRepository _repository;

    public EditClubMemberCommandHandler(IClubMemberRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(EditClubMemberCommand request, CancellationToken cancellationToken)
    {
        var clubMember = await _repository.GetTracking(request.Id);
        if (clubMember == null)
            return OperationResult.NotFound();

        clubMember.UpdateMemberCode(request.MemberCode);

        await _repository.Save();
        return OperationResult.Success();
    }
}
