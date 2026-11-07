using Club.Domain.LoyaltyCampaignAgg.Repository;
using Common.Application;

namespace Club.Application.LoyaltyCampaigns.MarkRecipientAsSent;

public class MarkRecipientAsSentCommandHandler : IBaseCommandHandler<MarkRecipientAsSentCommand>
{
    private readonly ILoyaltyCampaignRepository _repository;

    public MarkRecipientAsSentCommandHandler(ILoyaltyCampaignRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(MarkRecipientAsSentCommand request, CancellationToken cancellationToken)
    {
        var campaign = await _repository.GetTracking(request.CampaignId);
        if (campaign == null)
            return OperationResult.NotFound();

        campaign.MarkRecipientAsSent(request.CustomerId);
        await _repository.Save();

        return OperationResult.Success();
    }
}
