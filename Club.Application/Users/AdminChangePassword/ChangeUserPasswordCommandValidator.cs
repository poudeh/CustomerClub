using Common.Application.Validation;
using FluentValidation;

namespace Club.Application.Users.AdminChangePassword;

public class ChangeUserPasswordCommandValidator : AbstractValidator<ChangeUserPasswordCommand>
{
    public ChangeUserPasswordCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage(ValidationMessages.required("شناسه کاربر"));

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage(ValidationMessages.required("کلمه عبور"));
    }
}
