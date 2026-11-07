using Common.Application;

namespace Club.Application.LoyaltyCampaigns.Cancel;

public record CancelLoyaltyCampaignCommand(long Id) : IBaseCommand;
