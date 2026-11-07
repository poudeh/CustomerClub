using Common.Application;

namespace Club.Application.LoyaltyAccounts.Create;

public record CreateLoyaltyAccountCommand(long ClubMemberId) : IBaseCommand;
