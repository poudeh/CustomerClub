using Common.Application.Validation;
using FluentValidation;

namespace Club.Application.Users.ClearRoles;

public class ClearUserRolesCommandValidator : AbstractValidator<ClearUserRolesCommand>
{
    public ClearUserRolesCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage(ValidationMessages.required("شناسه کاربر"));
    }
}
