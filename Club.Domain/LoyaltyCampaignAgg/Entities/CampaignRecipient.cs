using Club.Domain.LoyaltyCampaignAgg.Enums;
using Common.Common.Domain;

namespace Club.Domain.LoyaltyCampaignAgg.Entities;
/// <summary>
/// Receptionist in the campaigns;
/// </summary>

public class CampaignRecipient : BaseEntity
{
    public long CustomerId { get; private set; }
    public long LoyalCampaignId { get; private set; }
    public string PhoneNumber { get; private set; }
    public CampaignRecipientStatus Status { get; private set; }
    public DateTime? SentAt { get; private set; }
    public string ErrorMessage { get; private set; }

    public virtual LoyaltyCampaign LoyaltyCampaign { get;  set; }
    protected CampaignRecipient()
    {
        
    }
    public CampaignRecipient(long customerId,long loyalCampaignId, string phoneNumber)
    {
        CustomerId = customerId;
        LoyalCampaignId = loyalCampaignId;
        PhoneNumber = phoneNumber;
        Status = CampaignRecipientStatus.Pending;
    }

    public void MarkAsSent()
    {
        if (Status != CampaignRecipientStatus.Pending)
            throw new InvalidOperationException(
                "Recipient has already been processed.");

        Status = CampaignRecipientStatus.Sent;
        SentAt = DateTime.UtcNow;
    }

    public void MarkAsFailed(string error)
    {
        if (Status != CampaignRecipientStatus.Pending)
            throw new InvalidOperationException(
                "Recipient has already been processed.");

        Status = CampaignRecipientStatus.Failed;
        ErrorMessage = error;
    }
}
