using Club.Domain.MembershipTierAgg.Repository;
using Common.Application;
using Common.Common.Application;

namespace Club.Application.MembershipTiers.RemoveRequirement;

public class RemoveTierRequirementCommandHandler : IBaseCommandHandler<RemoveTierRequirementCommand>
{
    private readonly IMembershipTierRepository _repository;

    public RemoveTierRequirementCommandHandler(IMembershipTierRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(RemoveTierRequirementCommand request, CancellationToken cancellationToken)
    {
        var tier = await _repository.GetTracking(request.TierId);
        if (tier == null)
            return OperationResult.NotFound();

        tier.RemoveRequirement(request.RequirementId);
        await _repository.Save();

        return OperationResult.Success();
    }
}
