using Club.Domain.ClubMemberAgg.Repository;
using Common.Application;
using Common.Common.Application;

namespace Club.Application.ClubMembers.UpdateMemberCode;

public class UpdateMemberCodeCommandHandler : IBaseCommandHandler<UpdateMemberCodeCommand>
{
    private readonly IClubMemberRepository _clubMemberRepository;
    public UpdateMemberCodeCommandHandler(
        IClubMemberRepository clubMemberRepository)
    {
        _clubMemberRepository = clubMemberRepository;
    }

    public async Task<OperationResult> Handle(UpdateMemberCodeCommand request, CancellationToken cancellationToken)
    {
        var member = await _clubMemberRepository.GetTracking(request.clubmemberId);
        if (member == null)
            return OperationResult.Error("عضو موردنظر یافت نشد.");
        member.UpdateMemberCode(request.memberCode);
        await _clubMemberRepository.Save();
        return OperationResult.Success();
    }
}