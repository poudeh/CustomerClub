using Club.Domain.MembershipTierAgg.Repository;
using Common.Application;
using Common.Common.Application;

namespace Club.Application.MembershipTiers.Edit;

public class EditMembershipTierCommandHandler : IBaseCommandHandler<EditMembershipTierCommand>
{
    private readonly IMembershipTierRepository _repository;

    public EditMembershipTierCommandHandler(IMembershipTierRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(EditMembershipTierCommand request, CancellationToken cancellationToken)
    {
        var tier = await _repository.GetTracking(request.Id);
        if (tier == null)
            return OperationResult.NotFound();

        tier.Edit(request.Title, request.Type);
        await _repository.Save();

        return OperationResult.Success();
    }
}
