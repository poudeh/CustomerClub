using Common.Application.Validation;
using FluentValidation;

namespace Club.Application.LoyaltyAccounts.Create;

public class CreateLoyaltyAccountCommandValidator : AbstractValidator<CreateLoyaltyAccountCommand>
{
    public CreateLoyaltyAccountCommandValidator()
    {
        RuleFor(x => x.ClubMemberId)
            .GreaterThan(0).WithMessage(ValidationMessages.required("شناسه عضو"));
    }
}
