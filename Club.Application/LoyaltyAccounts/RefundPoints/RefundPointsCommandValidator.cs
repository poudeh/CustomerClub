using Common.Application.Validation;
using FluentValidation;

namespace Club.Application.LoyaltyAccounts.RefundPoints;

public class RefundPointsCommandValidator : AbstractValidator<RefundPointsCommand>
{
    public RefundPointsCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage(ValidationMessages.required("شناسه حساب امتیازی"));

        RuleFor(x => x.Points)
            .GreaterThan(0).WithMessage("مقدار بازگشت امتیاز باید بیشتر از صفر باشد.");
    }
}
