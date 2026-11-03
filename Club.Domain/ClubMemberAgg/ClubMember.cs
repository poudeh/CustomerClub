using Club.Domain.ClubMemberAgg.Enums;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Club.Domain.ClubMemberAgg;
/// <summary>
/// Represents a customer's membership in the loyalty club.
/// Manages the membership lifecycle, including activation,
/// suspension, reactivation, and termination.
/// </summary>
public class ClubMember : AggregateRoot
{
    public string MemberCode { get; private set; }
    public Guid CustomerId { get; private set; }
    public MemberStatus Status { get; private set; }
    public DateTime JoinedAt { get; private set; }

    protected ClubMember()
    {
    }

    public ClubMember(Guid customerId, string memberCode)
    {
        if (customerId == Guid.Empty)
            throw new ArgumentException("CustomerId is required.");

        if (string.IsNullOrWhiteSpace(memberCode))
            throw new ArgumentException("MemberCode is required.");

        CustomerId = customerId;
        MemberCode = memberCode;
        Status = MemberStatus.Pending;
        JoinedAt = DateTime.UtcNow;
    }

    public void Activate()
    {
        if (Status != MemberStatus.Pending)
            throw new InvalidOperationException(
                "Only pending members can be activated.");

        Status = MemberStatus.Active;
    }

    public void Suspend()
    {
        if (Status != MemberStatus.Active)
            throw new InvalidOperationException(
                "Only active members can be suspended.");

        Status = MemberStatus.Suspended;
    }

    public void Reactivate()
    {
        if (Status != MemberStatus.Suspended)
            throw new InvalidOperationException(
                "Only suspended members can be reactivated.");

        Status = MemberStatus.Active;
    }

    public void Terminate()
    {
        if (Status == MemberStatus.Terminated)
            throw new InvalidOperationException(
                "Member is already terminated.");

        Status = MemberStatus.Terminated;
    }

    public void UpdateMemberCode(string memberCode)
    {
        if (string.IsNullOrWhiteSpace(memberCode))
            throw new ArgumentException("MemberCode is required.");

        MemberCode = memberCode;
    }

    public bool IsActive()
    {
        return Status == MemberStatus.Active;
    }
}
