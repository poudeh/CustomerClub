using Club.Domain.MembershipTierAgg.Enums;
using Common.Application;

namespace Club.Application.MembershipTiers.UpdateRequirement;

public record UpdateTierRequirementCommand(long TierId, long RequirementId, RequirementOperator Operator, decimal RequiredValue) : IBaseCommand;
