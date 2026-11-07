using Common.Application;

namespace Club.Application.ClubMembers.UpdateMemberCode;

public record UpdateMemberCodeCommand(long clubmemberId , string memberCode):IBaseCommand;