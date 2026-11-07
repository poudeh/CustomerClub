using Club.Domain.LoyaltyCampaignAgg.Repository;
using Common.Application;

namespace Club.Application.LoyaltyCampaigns.StartSending;

public class StartSendingCampaignCommandHandler : IBaseCommandHandler<StartSendingCampaignCommand>
{
    private readonly ILoyaltyCampaignRepository _repository;

    public StartSendingCampaignCommandHandler(ILoyaltyCampaignRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(StartSendingCampaignCommand request, CancellationToken cancellationToken)
    {
        var campaign = await _repository.GetTracking(request.Id);
        if (campaign == null)
            return OperationResult.NotFound();

        campaign.StartSending();
        await _repository.Save();

        return OperationResult.Success();
    }
}
