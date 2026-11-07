using Common.Application.Validation;
using FluentValidation;

namespace Club.Application.LoyaltyCampaigns.StartSending;

public class StartSendingCampaignCommandValidator : AbstractValidator<StartSendingCampaignCommand>
{
    public StartSendingCampaignCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage(ValidationMessages.required("شناسه کمپین"));
    }
}
