using Club.Domain.CustomerAgg.Enums;
using Common.Domain;

namespace Club.Domain.CustomerAgg;
/// <summary>
/// Represents a customer in the loyalty club system.
/// </summary>
public class Customer : AggregateRoot
{
    public string Name { get; private set; }
    public string NationalId { get; private set; }
    public string EconomicCode { get; private set; }
    public string PhoneNumber { get; private set; }
    public string Email { get; private set; }
    public CustomerType Type { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; private set; }

    protected Customer()
    {
    }

    public Customer(string name,string nationalId,string economicCode,string phoneNumber,string email,CustomerType type)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Customer name is required.");

        if (string.IsNullOrWhiteSpace(nationalId))
            throw new ArgumentException("NationalId is required.");

        Name = name;
        NationalId = nationalId;
        EconomicCode = economicCode;
        PhoneNumber = phoneNumber;
        Email = email;
        Type = type;

        IsActive = true;
        CreatedAt = DateTime.UtcNow;
    }

    public void Activate()
    {
        IsActive = true;
    }

    public void Deactivate()
    {
        IsActive = false;
    }

    public void UpdateContactInfo(string phoneNumber, string email)
    {
        PhoneNumber = phoneNumber;
        Email = email;
    }

    public void UpdateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Customer name is required.");

        Name = name;
    }
}