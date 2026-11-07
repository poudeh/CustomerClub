using Common.Application.Validation;
using FluentValidation;

namespace Club.Application.ClubMembers.ChangeClubMemberStatus;

public class ChangeClubMemberStatusCommandValidator : AbstractValidator<ChangeClubMemberStatusCommand>
{
    public ChangeClubMemberStatusCommandValidator()
    {
        RuleFor(x => x.ClubMemberId)
            .GreaterThan(0)
            .WithMessage(ValidationMessages.required("شناسه عضویت"));

        RuleFor(x => x.Status)
            .IsInEnum()
            .WithMessage("وضعیت عضویت نامعتبر است.");
    }
}