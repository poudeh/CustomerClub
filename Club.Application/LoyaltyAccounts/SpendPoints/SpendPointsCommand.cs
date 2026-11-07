using Common.Application;

namespace Club.Application.LoyaltyAccounts.SpendPoints;

public record SpendPointsCommand(long Id, decimal Points) : IBaseCommand;
