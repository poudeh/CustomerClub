using Common.Application.Validation;
using FluentValidation;

namespace Club.Application.LoyaltyAccounts.EarnPoints;

public class EarnPointsCommandValidator : AbstractValidator<EarnPointsCommand>
{
    public EarnPointsCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage(ValidationMessages.required("شناسه حساب امتیازی"));

        RuleFor(x => x.Points)
            .GreaterThan(0).WithMessage("امتیاز باید بیشتر از صفر باشد.");
    }
}
