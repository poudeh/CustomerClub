using Common.Application.Validation;
using FluentValidation;

namespace Club.Application.LoyaltyCampaigns.RemoveRecipient;

public class RemoveRecipientFromCampaignCommandValidator : AbstractValidator<RemoveRecipientFromCampaignCommand>
{
    public RemoveRecipientFromCampaignCommandValidator()
    {
        RuleFor(x => x.CampaignId)
            .GreaterThan(0).WithMessage(ValidationMessages.required("شناسه کمپین"));

        RuleFor(x => x.CustomerId)
            .GreaterThan(0).WithMessage(ValidationMessages.required("شناسه مشتری"));
    }
}
