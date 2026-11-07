using Common.Application.Validation;
using FluentValidation;

namespace Club.Application.LoyaltyCampaigns.MarkRecipientAsSent;

public class MarkRecipientAsSentCommandValidator : AbstractValidator<MarkRecipientAsSentCommand>
{
    public MarkRecipientAsSentCommandValidator()
    {
        RuleFor(x => x.CampaignId)
            .GreaterThan(0).WithMessage(ValidationMessages.required("شناسه کمپین"));

        RuleFor(x => x.CustomerId)
            .GreaterThan(0).WithMessage(ValidationMessages.required("شناسه مشتری"));
    }
}
