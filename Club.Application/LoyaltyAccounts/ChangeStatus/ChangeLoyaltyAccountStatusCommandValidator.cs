using Club.Domain.LoyaltyAccountAgg.Enums;
using Common.Application.Validation;
using FluentValidation;

namespace Club.Application.LoyaltyAccounts.ChangeStatus;

public class ChangeLoyaltyAccountStatusCommandValidator : AbstractValidator<ChangeLoyaltyAccountStatusCommand>
{
    public ChangeLoyaltyAccountStatusCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage(ValidationMessages.required("شناسه حساب امتیازی"));

        RuleFor(x => x.Status)
            .IsInEnum().WithMessage(ValidationMessages.required("وضعیت حساب امتیازی"));
    }
}
