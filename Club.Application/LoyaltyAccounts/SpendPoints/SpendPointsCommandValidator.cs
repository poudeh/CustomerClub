using Common.Application.Validation;
using FluentValidation;

namespace Club.Application.LoyaltyAccounts.SpendPoints;

public class SpendPointsCommandValidator : AbstractValidator<SpendPointsCommand>
{
    public SpendPointsCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage(ValidationMessages.required("شناسه حساب امتیازی"));

        RuleFor(x => x.Points)
            .GreaterThan(0).WithMessage("مقدار خرج امتیاز باید بیشتر از صفر باشد.");
    }
}
