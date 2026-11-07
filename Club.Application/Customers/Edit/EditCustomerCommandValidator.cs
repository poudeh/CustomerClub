using Club.Domain.CustomerAgg.Enums;
using Common.Application.Validation;
using FluentValidation;

namespace Club.Application.Customers.Edit;

public class EditCustomerCommandValidator : AbstractValidator<EditCustomerCommand>
{
    public EditCustomerCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage(ValidationMessages.required("شناسه مشتری"));

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage(ValidationMessages.required("نام مشتری"));

        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage(ValidationMessages.required("شماره تماس"));

        RuleFor(x => x.Type)
            .IsInEnum().WithMessage(ValidationMessages.required("نوع مشتری"));
    }
}
