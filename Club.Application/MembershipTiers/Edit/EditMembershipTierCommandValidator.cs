using Common.Application.Validation;
using FluentValidation;

namespace Club.Application.MembershipTiers.Edit;

public class EditMembershipTierCommandValidator : AbstractValidator<EditMembershipTierCommand>
{
    public EditMembershipTierCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage(ValidationMessages.required("شناسه سطح عضویت"));

        RuleFor(x => x.Title)
            .NotEmpty().WithMessage(ValidationMessages.required("عنوان سطح عضویت"));
    }
}
