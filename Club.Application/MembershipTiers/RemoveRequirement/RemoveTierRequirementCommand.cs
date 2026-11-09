using Common.Application;

namespace Club.Application.MembershipTiers.RemoveRequirement;

public record RemoveTierRequirementCommand(long TierId, long RequirementId) : IBaseCommand;
