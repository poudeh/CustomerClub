using Club.Domain.LoyaltyCampaignAgg.Repository;
using Common.Application;
using Common.Common.Application;

namespace Club.Application.LoyaltyCampaigns.MarkRecipientAsFailed;

public class MarkRecipientAsFailedCommandHandler : IBaseCommandHandler<MarkRecipientAsFailedCommand>
{
    private readonly ILoyaltyCampaignRepository _repository;

    public MarkRecipientAsFailedCommandHandler(ILoyaltyCampaignRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(MarkRecipientAsFailedCommand request, CancellationToken cancellationToken)
    {
        var campaign = await _repository.GetTracking(request.CampaignId);
        if (campaign == null)
            return OperationResult.NotFound();

        campaign.MarkRecipientAsFailed(request.CustomerId, request.Error);
        await _repository.Save();

        return OperationResult.Success();
    }
}
