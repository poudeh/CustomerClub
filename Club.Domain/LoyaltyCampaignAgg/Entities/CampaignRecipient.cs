using Club.Domain.LoyaltyCampaignAgg.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Club.Domain.LoyaltyCampaignAgg.Entities;

public class CampaignRecipient
{
    public Guid Id { get; private set; }

    public Guid CustomerId { get; private set; }

    public string PhoneNumber { get; private set; }

    public CampaignRecipientStatus Status { get; private set; }

    public DateTime? SentAt { get; private set; }

    public string ErrorMessage { get; private set; }

    protected CampaignRecipient()
    {
    }

    public CampaignRecipient(Guid customerId, string phoneNumber)
    {
        Id = Guid.NewGuid();
        CustomerId = customerId;
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
