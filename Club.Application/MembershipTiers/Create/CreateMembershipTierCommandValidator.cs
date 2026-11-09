using Club.Domain.MembershipTierAgg.Enums;
using Common.Application.Validation;
using FluentValidation;

namespace Club.Application.MembershipTiers.Create;

public class CreateMembershipTierCommandValidator : AbstractValidator<CreateMembershipTierCommand>
{
    public CreateMembershipTierCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage(ValidationMessages.required("عنوان سطح عضویت"));

        RuleFor(x => x.Type)
            .IsInEnum().WithMessage(ValidationMessages.required("نوع سطح عضویت"));
    }
}
