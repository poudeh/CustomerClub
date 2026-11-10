using Club.Domain.LoyaltyCampaignAgg.Repository;
using Common.Application;
using Common.Common.Application;

namespace Club.Application.LoyaltyCampaigns.RemoveRecipient;

public class RemoveRecipientFromCampaignCommandHandler : IBaseCommandHandler<RemoveRecipientFromCampaignCommand>
{
    private readonly ILoyaltyCampaignRepository _repository;

    public RemoveRecipientFromCampaignCommandHandler(ILoyaltyCampaignRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(RemoveRecipientFromCampaignCommand request, CancellationToken cancellationToken)
    {
        var campaign = await _repository.GetTracking(request.CampaignId);
        if (campaign == null)
            return OperationResult.NotFound();
        campaign.RemoveRecipient(request.CustomerId);
        await _repository.Save();
        return OperationResult.Success();
    }
}
