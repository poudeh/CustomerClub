using Common.Application.Validation;
using FluentValidation;

namespace Club.Application.Users.ToggleActivation;

public class ToggleUserActivationCommandValidator : AbstractValidator<ToggleUserActivationCommand>
{
    public ToggleUserActivationCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage(ValidationMessages.required("شناسه کاربر"));
    }
}
