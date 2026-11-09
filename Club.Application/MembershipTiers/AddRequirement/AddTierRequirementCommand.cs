using Club.Domain.MembershipTierAgg.Enums;
using Common.Application;

namespace Club.Application.MembershipTiers.AddRequirement;

public record AddTierRequirementCommand(long TierId, TierRequirementType Type, RequirementOperator Operator, decimal RequiredValue) : IBaseCommand;
