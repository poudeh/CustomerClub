using Common.Application;

namespace Club.Application.LoyaltyCampaigns.StartSending;

public record StartSendingCampaignCommand(long Id) : IBaseCommand;
