using Common.Application;

namespace Club.Application.LoyaltyAccounts.AdjustPoints;

public record AdjustPointsCommand(long Id, decimal Points) : IBaseCommand;
