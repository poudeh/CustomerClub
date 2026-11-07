using Club.Domain.LoyaltyCampaignAgg.Repository;
using Common.Application;

namespace Club.Application.LoyaltyCampaigns.Edit;

public class EditLoyaltyCampaignCommandHandler : IBaseCommandHandler<EditLoyaltyCampaignCommand>
{
    private readonly ILoyaltyCampaignRepository _repository;

    public EditLoyaltyCampaignCommandHandler(ILoyaltyCampaignRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(EditLoyaltyCampaignCommand request, CancellationToken cancellationToken)
    {
        var campaign = await _repository.GetTracking(request.Id);
        if (campaign == null)
            return OperationResult.NotFound();

        campaign.UpdateContent(request.Title, request.Message);
        await _repository.Save();

        return OperationResult.Success();
    }
}
