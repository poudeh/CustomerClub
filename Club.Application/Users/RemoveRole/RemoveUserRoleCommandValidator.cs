using Common.Application.Validation;
using FluentValidation;

namespace Club.Application.Users.RemoveRole;

public class RemoveUserRoleCommandValidator : AbstractValidator<RemoveUserRoleCommand>
{
    public RemoveUserRoleCommandValidator()
    {
        RuleFor(x => x.UserId)
            .GreaterThan(0).WithMessage(ValidationMessages.required("شناسه کاربر"));

        RuleFor(x => x.RoleId)
            .GreaterThan(0).WithMessage(ValidationMessages.required("شناسه نقش"));
    }
}
