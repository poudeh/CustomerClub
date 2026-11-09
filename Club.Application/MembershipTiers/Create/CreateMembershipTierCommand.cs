using Club.Domain.MembershipTierAgg.Enums;
using Common.Application;

namespace Club.Application.MembershipTiers.Create;

public record CreateMembershipTierCommand(string Title, TierType Type) : IBaseCommand;
