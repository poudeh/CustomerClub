using Club.Domain.LoyaltyAccountAgg.Enums;
using Common.Application;

namespace Club.Application.LoyaltyAccounts.ChangeStatus;

public record ChangeLoyaltyAccountStatusCommand(long Id, LoyaltyAccountStatus Status) : IBaseCommand;
