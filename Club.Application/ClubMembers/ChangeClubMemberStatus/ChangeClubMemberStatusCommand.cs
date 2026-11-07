using Club.Domain.ClubMemberAgg.Enums;
using Common.Application;

namespace Club.Application.ClubMembers.ChangeClubMemberStatus;

public record ChangeClubMemberStatusCommand(long ClubMemberId, MemberStatus Status) : IBaseCommand;