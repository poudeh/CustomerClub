using Common.Application;

namespace Club.Application.LoyaltyCampaigns.Create;

public record CreateLoyaltyCampaignCommand(string Title, string Message) : IBaseCommand;
