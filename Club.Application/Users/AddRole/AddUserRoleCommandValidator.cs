using Common.Application.Validation;
using FluentValidation;

namespace Club.Application.Users.AddRole;

public class AddUserRoleCommandValidator : AbstractValidator<AddUserRoleCommand>
{
    public AddUserRoleCommandValidator()
    {
        RuleFor(x => x.UserId)
            .GreaterThan(0).WithMessage(ValidationMessages.required("شناسه کاربر"));

        RuleFor(x => x.RoleId)
            .GreaterThan(0).WithMessage(ValidationMessages.required("شناسه نقش"));
    }
}
