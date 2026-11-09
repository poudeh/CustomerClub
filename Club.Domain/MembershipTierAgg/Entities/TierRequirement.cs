using Club.Domain.MembershipTierAgg.Enums;
using Common.Common.Domain;

namespace Club.Domain.MembershipTierAgg.Entities;

public class TierRequirement : BaseEntity
{
    public long MembershipTierId { get; set; }
    public TierRequirementType Type { get; private set; }
    public RequirementOperator Operator { get; private set;}
    public decimal RequiredValue { get; private set; }

    public virtual MembershipTier MembershipTier { get; set; }
    protected TierRequirement()
    {
    }
    public TierRequirement(TierRequirementType type,  RequirementOperator requirementOperator, decimal requiredValue)
    {
        Validate(requiredValue);

        Type = type;
        Operator = requirementOperator;
        RequiredValue = requiredValue;
    }

    public void Update(RequirementOperator requirementOperator,decimal requiredValue)
    {
        Validate(requiredValue);
        Operator = requirementOperator;
        RequiredValue = requiredValue;
    }

    private static void Validate(decimal value)
    {
        if (value < 0)
            throw new ArgumentException(
                "RequiredValue cannot be negative.");
    }
}
