using Common.Application;

namespace Club.Application.LoyaltyCampaigns.RemoveRecipient;

public record RemoveRecipientFromCampaignCommand(long CampaignId, long CustomerId) : IBaseCommand;
