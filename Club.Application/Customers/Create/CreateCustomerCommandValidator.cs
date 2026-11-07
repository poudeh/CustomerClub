using Club.Domain.CustomerAgg.Enums;
using Common.Application.Validation;
using FluentValidation;

namespace Club.Application.Customers.Create;

public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage(ValidationMessages.required("نام مشتری"));

        RuleFor(x => x.NationalId)
            .NotEmpty().WithMessage(ValidationMessages.required("کد ملی"));

        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage(ValidationMessages.required("شماره تماس"));

        RuleFor(x => x.Type)
            .IsInEnum().WithMessage(ValidationMessages.required("نوع مشتری"));
    }
}
