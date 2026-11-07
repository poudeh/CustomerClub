using Common.Application;

namespace Club.Application.LoyaltyAccounts.RefundPoints;

public record RefundPointsCommand(long Id, decimal Points) : IBaseCommand;
