using Common.Application;

namespace Club.Application.ClubMembers.Create;

public record CreateClubMemberCommand(long CustomerId, string MemberCode) : IBaseCommand;
