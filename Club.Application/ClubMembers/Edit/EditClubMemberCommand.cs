using Common.Application;

namespace Club.Application.ClubMembers.Edit;

public record EditClubMemberCommand(long Id, long CustomerId, string MemberCode) : IBaseCommand;
