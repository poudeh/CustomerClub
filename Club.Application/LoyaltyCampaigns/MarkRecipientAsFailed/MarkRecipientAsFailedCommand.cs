using Common.Application;

namespace Club.Application.LoyaltyCampaigns.MarkRecipientAsFailed;

public record MarkRecipientAsFailedCommand(long CampaignId, long CustomerId, string Error) : IBaseCommand;
