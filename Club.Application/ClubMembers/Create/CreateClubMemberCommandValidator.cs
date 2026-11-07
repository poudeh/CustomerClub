using Common.Application.Validation;
using FluentValidation;

namespace Club.Application.ClubMembers.Create;

public class CreateClubMemberCommandValidator : AbstractValidator<CreateClubMemberCommand>
{
    public CreateClubMemberCommandValidator()
    {
        RuleFor(x => x.CustomerId)
            .GreaterThan(0).WithMessage(ValidationMessages.required("شناسه مشتری"));

        RuleFor(x => x.MemberCode)
            .NotEmpty().WithMessage(ValidationMessages.required("کد عضویت"));
    }
}
