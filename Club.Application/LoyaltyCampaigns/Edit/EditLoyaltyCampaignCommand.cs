using Common.Application;

namespace Club.Application.LoyaltyCampaigns.Edit;

public record EditLoyaltyCampaignCommand(long Id, string Title, string Message) : IBaseCommand;
