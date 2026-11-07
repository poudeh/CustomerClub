using Common.Application.Validation;
using FluentValidation;

namespace Club.Application.LoyaltyCampaigns.Cancel;

public class CancelLoyaltyCampaignCommandValidator : AbstractValidator<CancelLoyaltyCampaignCommand>
{
    public CancelLoyaltyCampaignCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage(ValidationMessages.required("شناسه کمپین"));
    }
}
