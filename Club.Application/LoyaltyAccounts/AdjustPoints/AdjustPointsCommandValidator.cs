using Common.Application.Validation;
using FluentValidation;

namespace Club.Application.LoyaltyAccounts.AdjustPoints;

public class AdjustPointsCommandValidator : AbstractValidator<AdjustPointsCommand>
{
    public AdjustPointsCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage(ValidationMessages.required("شناسه حساب امتیازی"));
    }
}
