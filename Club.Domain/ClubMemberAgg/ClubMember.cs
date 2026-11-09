using Club.Domain.ClubMemberAgg.Enums;
using Club.Domain.CustomerAgg;
using Club.Domain.LoyaltyAccountAgg;
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

    public virtual Customer Customer { get; set; }
    public virtual LoyaltyAccount LoyaltyAccount { get; set; }

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
    }

    public void ChangeStatus(MemberStatus status)
    {
        Status = status switch
        {
            MemberStatus.Active when Status != MemberStatus.Pending && Status != MemberStatus.Suspended => throw
                new InvalidOperationException("فقط اعضای در انتظار تأیید یا تعلیق‌شده قابلیت فعال‌سازی دارند."),
            MemberStatus.Suspended when Status != MemberStatus.Active => throw new InvalidOperationException(
                "فقط اعضای فعال قابلیت تعلیق دارند."),
            MemberStatus.Terminated when Status == MemberStatus.Terminated => throw new InvalidOperationException(
                "عضویت قبلاً خاتمه یافته است."),
            MemberStatus.Pending => throw new InvalidOperationException(
                "تغییر وضعیت عضو به در انتظار تأیید مجاز نیست."),
            _ => status
        };
    }

    public void UpdateMemberCode(string memberCode)
    {
        if (string.IsNullOrWhiteSpace(memberCode))
            throw new ArgumentException("MemberCode is required.");

        MemberCode = memberCode;
    }
}
