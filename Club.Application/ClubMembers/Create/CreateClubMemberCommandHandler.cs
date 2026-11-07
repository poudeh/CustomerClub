using Club.Domain.ClubMemberAgg;
using Club.Domain.ClubMemberAgg.Repository;
using Common.Application;

namespace Club.Application.ClubMembers.Create;

public class CreateClubMemberCommandHandler : IBaseCommandHandler<CreateClubMemberCommand>
{
    private readonly IClubMemberRepository _repository;

    public CreateClubMemberCommandHandler(IClubMemberRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(CreateClubMemberCommand request, CancellationToken cancellationToken)
    {
        var clubMember = new ClubMember(request.CustomerId, request.MemberCode);

        await _repository.AddAsync(clubMember);
        await _repository.Save();

        return OperationResult.Success();
    }
}
