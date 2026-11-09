using Club.Domain.MembershipTierAgg.Enums;
using Common.Application;

namespace Club.Application.MembershipTiers.Edit;

public record EditMembershipTierCommand(long Id, string Title, TierType Type) : IBaseCommand;
