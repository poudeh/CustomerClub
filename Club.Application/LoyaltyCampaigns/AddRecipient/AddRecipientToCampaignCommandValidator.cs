using Common.Application.Validation;
using FluentValidation;

namespace Club.Application.LoyaltyCampaigns.AddRecipient;

public class AddRecipientToCampaignCommandValidator : AbstractValidator<AddRecipientToCampaignCommand>
{
    public AddRecipientToCampaignCommandValidator()
    {
        RuleFor(x => x.CampaignId)
            .GreaterThan(0).WithMessage(ValidationMessages.required("شناسه کمپین"));

        RuleFor(x => x.CustomerId)
            .GreaterThan(0).WithMessage(ValidationMessages.required("شناسه مشتری"));

        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage(ValidationMessages.required("شماره تماس"));
    }
}
