using Common.Application.Validation;
using FluentValidation;

namespace Club.Application.LoyaltyCampaigns.Edit;

public class EditLoyaltyCampaignCommandValidator : AbstractValidator<EditLoyaltyCampaignCommand>
{
    public EditLoyaltyCampaignCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage(ValidationMessages.required("شناسه کمپین"));

        RuleFor(x => x.Title)
            .NotEmpty().WithMessage(ValidationMessages.required("عنوان کمپین"));

        RuleFor(x => x.Message)
            .NotEmpty().WithMessage(ValidationMessages.required("پیام کمپین"));
    }
}
