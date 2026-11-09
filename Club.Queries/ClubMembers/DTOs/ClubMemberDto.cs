using Club.Domain.ClubMemberAgg.Enums;
using Common.Query;
namespace Club.Queries.ClubMembers.DTOs;

public class ClubMemberDto : BaseDto
{
    public string MemberCode { get;  set; }
    public MemberStatus Status { get;  set; }

}