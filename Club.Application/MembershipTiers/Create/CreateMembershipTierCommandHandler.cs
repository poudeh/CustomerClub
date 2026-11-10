using Club.Domain.MembershipTierAgg;
using Club.Domain.MembershipTierAgg.Repository;
using Common.Application;
using Common.Common.Application;

namespace Club.Application.MembershipTiers.Create;

public class CreateMembershipTierCommandHandler : IBaseCommandHandler<CreateMembershipTierCommand>
{
    private readonly IMembershipTierRepository _repository;

    public CreateMembershipTierCommandHandler(IMembershipTierRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(CreateMembershipTierCommand request, CancellationToken cancellationToken)
    {
        var tier = new MembershipTier(request.Title, request.Type);

        await _repository.AddAsync(tier);
        await _repository.Save();

        return OperationResult.Success();
    }
}
