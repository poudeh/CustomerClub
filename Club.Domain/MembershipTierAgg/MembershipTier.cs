using Club.Domain.MembershipTierAgg.Entities;
using Club.Domain.MembershipTierAgg.Enums;
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

    public MembershipTier(string title, TierType type)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Tier title is required.");

        Title = title;
        Type = type;
    }

    public void Edit(string title, TierType type)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Tier title is required.");

        Title = title;
        Type = type;
    }

    // CREATE
    public void AddRequirement(TierRequirementType type, RequirementOperator requirementOperator, decimal requiredValue)
    {
        if (_requirements.Any(x => x.Type == type))
            throw new InvalidOperationException(
                "This requirement already exists.");
        _requirements.Add(new TierRequirement(type, requirementOperator, requiredValue));
    }

    // UPDATE
    public void UpdateRequirement(long requirementId, RequirementOperator requirementOperator, decimal requiredValue)
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
