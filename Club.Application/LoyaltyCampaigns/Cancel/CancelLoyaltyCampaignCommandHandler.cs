using Club.Domain.LoyaltyCampaignAgg.Repository;
using Common.Application;

namespace Club.Application.LoyaltyCampaigns.Cancel;

public class CancelLoyaltyCampaignCommandHandler : IBaseCommandHandler<CancelLoyaltyCampaignCommand>
{
    private readonly ILoyaltyCampaignRepository _repository;

    public CancelLoyaltyCampaignCommandHandler(ILoyaltyCampaignRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(CancelLoyaltyCampaignCommand request, CancellationToken cancellationToken)
    {
        var campaign = await _repository.GetTracking(request.Id);
        if (campaign == null)
            return OperationResult.NotFound();

        campaign.Cancel();
        await _repository.Save();

        return OperationResult.Success();
    }
}
