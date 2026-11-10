using Club.Domain.LoyaltyCampaignAgg.Repository;
using Common.Application;
using Common.Common.Application;

namespace Club.Application.LoyaltyCampaigns.AddRecipient;

public class AddRecipientToCampaignCommandHandler : IBaseCommandHandler<AddRecipientToCampaignCommand>
{
    private readonly ILoyaltyCampaignRepository _repository;

    public AddRecipientToCampaignCommandHandler(ILoyaltyCampaignRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(AddRecipientToCampaignCommand request, CancellationToken cancellationToken)
    {
        var campaign = await _repository.GetTracking(request.CampaignId);
        if (campaign == null)
            return OperationResult.NotFound();
        campaign.AddRecipient(request.CustomerId, request.CampaignId, request.PhoneNumber);
        await _repository.Save();
        return OperationResult.Success();
    }
}
