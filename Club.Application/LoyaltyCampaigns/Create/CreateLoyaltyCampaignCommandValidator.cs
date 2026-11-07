using Common.Application.Validation;
using FluentValidation;

namespace Club.Application.LoyaltyCampaigns.Create;

public class CreateLoyaltyCampaignCommandValidator : AbstractValidator<CreateLoyaltyCampaignCommand>
{
    public CreateLoyaltyCampaignCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage(ValidationMessages.required("عنوان کمپین"));

        RuleFor(x => x.Message)
            .NotEmpty().WithMessage(ValidationMessages.required("پیام کمپین"));
    }
}
