using Club.Domain.ClubMemberAgg;
using Club.Domain.LoyaltyAccountAgg.Enums;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace Club.Domain.LoyaltyAccountAgg;
/// <summary>
/// مسئول مدیریت حساب امتیازی عضو باشگاه مشتریان است؛
/// یعنی تمام عملیات مالی مبتنی بر امتیاز و کنترل موجودی امتیازهای مشتری در این کلاس انجام می‌شود.
/// </summary>
public class LoyaltyAccount : AggregateRoot
{
    public long ClubMemberId { get; private set; }
    public decimal Balance { get; private set; }
    public decimal TotalEarnedPoints { get; private set; }
    public decimal TotalSpentPoints { get; private set; }
    public LoyaltyAccountStatus Status { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? LastUpdatedAt { get; private set; }
    protected LoyaltyAccount()
    {
    }
    public LoyaltyAccount(long clubMemberId)
    {

        ClubMemberId = clubMemberId;
        Balance = 0;
        TotalEarnedPoints = 0;
        TotalSpentPoints = 0;
        Status = LoyaltyAccountStatus.Active;
        CreatedAt = DateTime.UtcNow;
    }


    public void EarnPoints(decimal points)
    {
        EnsureAccountIsActive();

        if (points <= 0)
            throw new ArgumentException("Points must be greater than zero.");

        Balance += points;
        TotalEarnedPoints += points;

        UpdateLastModified();
    }


    public void SpendPoints(decimal points)
    {
        EnsureAccountIsActive();

        if (points <= 0)
            throw new ArgumentException("Points must be greater than zero.");

        if (points > Balance)
            throw new InvalidOperationException(
                "Insufficient points balance.");

        Balance -= points;
        TotalSpentPoints += points;

        UpdateLastModified();
    }


    public void RefundPoints(decimal points)
    {
        EnsureAccountIsActive();

        if (points <= 0)
            throw new ArgumentException("Points must be greater than zero.");

        if (points > TotalSpentPoints)
            throw new InvalidOperationException(
                "Refund points cannot exceed total spent points.");

        Balance += points;
        TotalSpentPoints -= points;

        UpdateLastModified();
    }


    public void AdjustPoints(decimal points)
    {
        EnsureAccountIsActive();

        if (Balance + points < 0)
            throw new InvalidOperationException(
                "Balance cannot be negative.");

        Balance += points;

        if (points > 0)
            TotalEarnedPoints += points;

        UpdateLastModified();
    }


    public void Block()
    {
        if (Status != LoyaltyAccountStatus.Active)
            throw new InvalidOperationException(
                "Only active accounts can be blocked.");

        Status = LoyaltyAccountStatus.Blocked;

        UpdateLastModified();
    }


    public void Unblock()
    {
        if (Status != LoyaltyAccountStatus.Blocked)
            throw new InvalidOperationException(
                "Only blocked accounts can be unblocked.");

        Status = LoyaltyAccountStatus.Active;

        UpdateLastModified();
    }


    public void Close()
    {
        if (Status == LoyaltyAccountStatus.Closed)
            throw new InvalidOperationException(
                "Account is already closed.");

        Status = LoyaltyAccountStatus.Closed;

        UpdateLastModified();
    }


    private void EnsureAccountIsActive()
    {
        if (Status != LoyaltyAccountStatus.Active)
            throw new InvalidOperationException(
                "Loyalty account is not active.");
    }


    private void UpdateLastModified()
    {
        LastUpdatedAt = DateTime.UtcNow;
    }
}
