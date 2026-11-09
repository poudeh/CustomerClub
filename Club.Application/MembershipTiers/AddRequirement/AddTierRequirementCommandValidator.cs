using Club.Domain.MembershipTierAgg.Enums;
using Common.Application.Validation;
using FluentValidation;

namespace Club.Application.MembershipTiers.AddRequirement;

public class AddTierRequirementCommandValidator : AbstractValidator<AddTierRequirementCommand>
{
    public AddTierRequirementCommandValidator()
    {
        RuleFor(x => x.TierId)
            .GreaterThan(0).WithMessage(ValidationMessages.required("شناسه سطح عضویت"));

        RuleFor(x => x.Type)
            .IsInEnum().WithMessage(ValidationMessages.required("نوع شرط"));

        RuleFor(x => x.Operator)
            .IsInEnum().WithMessage(ValidationMessages.required("عملگر شرط"));

        RuleFor(x => x.RequiredValue)
            .GreaterThanOrEqualTo(0).WithMessage("مقدار شرط باید بزرگتر یا مساوی صفر باشد.");
    }
}
