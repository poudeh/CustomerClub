using Common.Application;

namespace Club.Application.LoyaltyCampaigns.AddRecipient;

public record AddRecipientToCampaignCommand(long CampaignId, long CustomerId, string PhoneNumber) : IBaseCommand;
