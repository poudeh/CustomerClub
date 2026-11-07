using Club.Domain.ClubMemberAgg.Enums;
using Common.Common.Domain;

namespace Club.Domain.ClubMemberAgg;
/// <summary>
/// Represents a customer's membership in the loyalty club.
/// Manages the membership lifecycle, including activation,
/// suspension, reactivation, and termination.
/// </summary>
public class ClubMember : AggregateRoot
{
    public string MemberCode { get; private set; }
    public long CustomerId { get; private set; }
    public MemberStatus Status { get; private set; }
    public DateTime JoinedAt { get; private set; }

    protected ClubMember()
    {
    }

    public ClubMember(long customerId, string memberCode)
    {
        if (customerId <= 0)
            throw new ArgumentException("CustomerId cannot be Negative.");

        if (string.IsNullOrWhiteSpace(memberCode))
            throw new ArgumentException("MemberCode is required.");

        CustomerId = customerId;
        MemberCode = memberCode;
        Status = MemberStatus.Pending;
        JoinedAt = DateTime.UtcNow;
    }

    public void ChangeStatus(MemberStatus status)
    {
        if (status == MemberStatus.Active)
        {
            if (Status != MemberStatus.Pending &&
                Status != MemberStatus.Suspended)
                throw new InvalidOperationException(
                    "فقط اعضای در انتظار تأیید یا تعلیق‌شده قابلیت فعال‌سازی دارند.");
        }
        else if (status == MemberStatus.Suspended)
        {
            if (Status != MemberStatus.Active)
                throw new InvalidOperationException(
                    "فقط اعضای فعال قابلیت تعلیق دارند.");
        }
        else if (status == MemberStatus.Terminated)
        {
            if (Status == MemberStatus.Terminated)
                throw new InvalidOperationException(
                    "عضویت قبلاً خاتمه یافته است.");
        }
        else if (status == MemberStatus.Pending)
        {
            throw new InvalidOperationException(
                "تغییر وضعیت عضو به در انتظار تأیید مجاز نیست.");
        }

        Status = status;
    }

    public void UpdateMemberCode(string memberCode)
    {
        if (string.IsNullOrWhiteSpace(memberCode))
            throw new ArgumentException("MemberCode is required.");

        MemberCode = memberCode;
    }
}
