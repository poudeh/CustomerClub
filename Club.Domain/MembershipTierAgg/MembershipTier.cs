using Club.Domain.MembershipTierAgg.Entities;
using Club.Domain.MembershipTierAgg.Enums;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Common.Common.Domain;

namespace Club.Domain.MembershipTierAgg;
/// <summary>
///  مسئول تعریف سطح‌های عضویت و مدیریت شرایط و معیارهای لازم برای قرار گرفتن مشتری در هر سطح است.
/// </summary>
public class MembershipTier : AggregateRoot
{
    public string Title { get; private set; }
    public TierType Type { get; private set; }
    private readonly List<TierRequirement> _requirements = new();
    public IReadOnlyCollection<TierRequirement> Requirements => _requirements.AsReadOnly();

    protected MembershipTier()
    {
    }

    // CREATE
    public void AddRequirement( TierRequirementType type, RequirementOperator requirementOperator, decimal requiredValue)
    {
        if (_requirements.Any(x => x.Type == type))
            throw new InvalidOperationException(
                "This requirement already exists.");

        _requirements.Add(
            new TierRequirement(
                type,
                requirementOperator,
                requiredValue));
    }

    // UPDATE
    public void UpdateRequirement( long requirementId, RequirementOperator requirementOperator, decimal requiredValue)
    {
        var requirement = _requirements
            .FirstOrDefault(x => x.Id == requirementId);

        if (requirement == null)
            throw new InvalidOperationException(
                "Requirement not found.");

        requirement.Update(requirementOperator, requiredValue);
    }

    // DELETE
    public void RemoveRequirement(long requirementId)
    {
        var requirement = _requirements
            .FirstOrDefault(x => x.Id == requirementId);

        if (requirement == null)
            throw new InvalidOperationException(
                "Requirement not found.");

        _requirements.Remove(requirement);
    }
}
