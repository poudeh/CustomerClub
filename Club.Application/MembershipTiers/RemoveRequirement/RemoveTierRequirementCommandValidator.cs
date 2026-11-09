using Common.Application.Validation;
using FluentValidation;

namespace Club.Application.MembershipTiers.RemoveRequirement;

public class RemoveTierRequirementCommandValidator : AbstractValidator<RemoveTierRequirementCommand>
{
    public RemoveTierRequirementCommandValidator()
    {
        RuleFor(x => x.TierId)
            .GreaterThan(0).WithMessage(ValidationMessages.required("شناسه سطح عضویت"));

        RuleFor(x => x.RequirementId)
            .GreaterThan(0).WithMessage(ValidationMessages.required("شناسه شرط"));
    }
}
