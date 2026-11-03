using Club.Domain.LoyaltyCampaignAgg.Entities;
using Club.Domain.LoyaltyCampaignAgg.Enums;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Club.Domain.LoyaltyCampaignAgg;

public class LoyaltyCampaign:AggregateRoot
{
    public string Title { get; private set; }
    public string Message { get; private set; }

    public LoyaltyCampaignStatus Status { get; private set; }

    public DateTime CreatedAt { get; private set; }
    public DateTime? SentAt { get; private set; }

    private readonly List<CampaignRecipient> _recipients = new();

    public IReadOnlyCollection<CampaignRecipient> Recipients =>
        _recipients.AsReadOnly();

    protected LoyaltyCampaign()
    {
    }

    public LoyaltyCampaign(string title, string message)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Campaign title is required.");

        if (string.IsNullOrWhiteSpace(message))
            throw new ArgumentException("Campaign message is required.");

        Title = title;
        Message = message;
        Status = LoyaltyCampaignStatus.Draft;
        CreatedAt = DateTime.UtcNow;
    }

    // ADD RECIPIENT
    public void AddRecipient(Guid customerId, string phoneNumber)
    {
        EnsureCampaignIsEditable();

        if (customerId == Guid.Empty)
            throw new ArgumentException("CustomerId is required.");

        if (string.IsNullOrWhiteSpace(phoneNumber))
            throw new ArgumentException("Phone number is required.");

        if (_recipients.Any(x => x.CustomerId == customerId))
            throw new InvalidOperationException(
                "Customer already exists in this campaign.");

        _recipients.Add(new CampaignRecipient(customerId, phoneNumber));
    }

    // REMOVE RECIPIENT
    public void RemoveRecipient(Guid customerId)
    {
        EnsureCampaignIsEditable();

        var recipient = _recipients
            .FirstOrDefault(x => x.CustomerId == customerId);

        if (recipient == null)
            throw new InvalidOperationException("Recipient not found.");

        _recipients.Remove(recipient);
    }

    // UPDATE CAMPAIGN
    public void UpdateContent(string title, string message)
    {
        EnsureCampaignIsEditable();

        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Campaign title is required.");

        if (string.IsNullOrWhiteSpace(message))
            throw new ArgumentException("Campaign message is required.");

        Title = title;
        Message = message;
    }

    // START SENDING
    public void StartSending()
    {
        if (Status != LoyaltyCampaignStatus.Draft)
            throw new InvalidOperationException(
                "Only draft campaigns can be started.");

        if (!_recipients.Any())
            throw new InvalidOperationException(
                "Campaign must have at least one recipient.");

        Status = LoyaltyCampaignStatus.Sending;
    }

    // MARK RECIPIENT AS SENT
    public void MarkRecipientAsSent(Guid customerId)
    {
        EnsureCampaignIsSending();

        var recipient = GetRecipient(customerId);

        recipient.MarkAsSent();

        CompleteCampaignIfFinished();
    }

    // MARK RECIPIENT AS FAILED
    public void MarkRecipientAsFailed(Guid customerId, string error)
    {
        EnsureCampaignIsSending();

        var recipient = GetRecipient(customerId);

        recipient.MarkAsFailed(error);

        CompleteCampaignIfFinished();
    }

    // CANCEL CAMPAIGN
    public void Cancel()
    {
        if (Status != LoyaltyCampaignStatus.Draft)
            throw new InvalidOperationException(
                "Only draft campaigns can be cancelled.");

        Status = LoyaltyCampaignStatus.Cancelled;
    }

    private CampaignRecipient GetRecipient(Guid customerId)
    {
        return _recipients.FirstOrDefault(x => x.CustomerId == customerId)
            ?? throw new InvalidOperationException("Recipient not found.");
    }

    private void EnsureCampaignIsEditable()
    {
        if (Status != LoyaltyCampaignStatus.Draft)
            throw new InvalidOperationException(
                "Campaign cannot be modified.");
    }

    private void EnsureCampaignIsSending()
    {
        if (Status != LoyaltyCampaignStatus.Sending)
            throw new InvalidOperationException(
                "Campaign is not in sending state.");
    }

    private void CompleteCampaignIfFinished()
    {
        if (_recipients.All(x =>
            x.Status != CampaignRecipientStatus.Pending))
        {
            Status = LoyaltyCampaignStatus.Completed;
            SentAt = DateTime.UtcNow;
        }
    }
}
