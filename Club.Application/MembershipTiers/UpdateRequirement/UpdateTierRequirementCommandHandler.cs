using Club.Domain.MembershipTierAgg.Repository;
using Common.Application;
using Common.Common.Application;

namespace Club.Application.MembershipTiers.UpdateRequirement;

public class UpdateTierRequirementCommandHandler : IBaseCommandHandler<UpdateTierRequirementCommand>
{
    private readonly IMembershipTierRepository _repository;

    public UpdateTierRequirementCommandHandler(IMembershipTierRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(UpdateTierRequirementCommand request, CancellationToken cancellationToken)
    {
        var tier = await _repository.GetTracking(request.TierId);
        if (tier == null)
            return OperationResult.NotFound();

        tier.UpdateRequirement(request.RequirementId, request.Operator, request.RequiredValue);
        await _repository.Save();

        return OperationResult.Success();
    }
}
