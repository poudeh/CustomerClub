using Common.Application;

namespace Club.Application.LoyaltyAccounts.EarnPoints;

public record EarnPointsCommand(long Id, decimal Points) : IBaseCommand;
