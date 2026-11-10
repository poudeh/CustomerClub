using Club.Domain.LoyaltyCampaignAgg;
using Club.Domain.LoyaltyCampaignAgg.Repository;
using Common.Application;
using Common.Common.Application;

namespace Club.Application.LoyaltyCampaigns.Create;

public class CreateLoyaltyCampaignCommandHandler : IBaseCommandHandler<CreateLoyaltyCampaignCommand>
{
    private readonly ILoyaltyCampaignRepository _repository;

    public CreateLoyaltyCampaignCommandHandler(ILoyaltyCampaignRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(CreateLoyaltyCampaignCommand request, CancellationToken cancellationToken)
    {
        var campaign = new LoyaltyCampaign(request.Title, request.Message);

        await _repository.AddAsync(campaign);
        await _repository.Save();

        return OperationResult.Success();
    }
}
