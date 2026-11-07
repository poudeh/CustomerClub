using Common.Application.Validation;
using FluentValidation;

namespace Club.Application.LoyaltyCampaigns.MarkRecipientAsFailed;

public class MarkRecipientAsFailedCommandValidator : AbstractValidator<MarkRecipientAsFailedCommand>
{
    public MarkRecipientAsFailedCommandValidator()
    {
        RuleFor(x => x.CampaignId)
            .GreaterThan(0).WithMessage(ValidationMessages.required("شناسه کمپین"));

        RuleFor(x => x.CustomerId)
            .GreaterThan(0).WithMessage(ValidationMessages.required("شناسه مشتری"));

        RuleFor(x => x.Error)
            .NotEmpty().WithMessage(ValidationMessages.required("دلیل خطا"));
    }
}
