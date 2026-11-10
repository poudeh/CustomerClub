using Club.Domain.ClubMemberAgg.Enums;

namespace Club.Queries.ClubMembers.DTOs;

public class ClubMemberFilterData
{
    public string MemberCode { get;  set; }
    public long CustomerId { get;  set; }
    public string CustomerName { get; set; }
    public MemberStatus Status { get;  set; }
}