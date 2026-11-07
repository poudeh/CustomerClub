using Common.Application;

namespace Club.Application.LoyaltyCampaigns.MarkRecipientAsSent;

public record MarkRecipientAsSentCommand(long CampaignId, long CustomerId) : IBaseCommand;
