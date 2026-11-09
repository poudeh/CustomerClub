using Common.Application.Validation;
using FluentValidation;

namespace Club.Application.Users.RemoveCustomer;

public class RemoveUserCustomerCommandValidator : AbstractValidator<RemoveUserCustomerCommand>
{
    public RemoveUserCustomerCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage(ValidationMessages.required("شناسه کاربر"));
    }
}
