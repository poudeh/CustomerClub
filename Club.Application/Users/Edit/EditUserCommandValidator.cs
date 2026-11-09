using Common.Application.Validation;
using FluentValidation;

namespace Club.Application.Users.Edit;

public class EditUserCommandValidator : AbstractValidator<EditUserCommand>
{
    public EditUserCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage(ValidationMessages.required("شناسه کاربر"));

        RuleFor(x => x.Username)
            .NotEmpty().WithMessage(ValidationMessages.required("نام کاربری"));
    }
}
