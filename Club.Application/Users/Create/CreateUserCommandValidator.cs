using Common.Application.Validation;
using FluentValidation;

namespace Club.Application.Users.Create;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty().WithMessage(ValidationMessages.required("نام کاربری"));

        RuleFor(x => x.PasswordHash)
            .NotEmpty().WithMessage(ValidationMessages.required("کلمه عبور"));
    }
}
