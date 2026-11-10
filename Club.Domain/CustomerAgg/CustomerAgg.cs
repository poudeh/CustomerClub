using Club.Domain.ClubMemberAgg;
using Club.Domain.CustomerAgg.Enums;
using Club.Domain.UserAgg;
using Common.Common.Domain;
using Common.Domain;

namespace Club.Domain.CustomerAgg;
/// <summary>
/// Represents a customer in the loyalty club system.
/// </summary>
public class Customer : AggregateRoot
{
    public string Name { get; private set; }
    public string NationalId { get; private set; }
    public string? EconomicCode { get; private set; }
    public string PhoneNumber { get; private set; }
    public string Email { get; private set; }
    public CustomerType Type { get; private set; }
    public bool IsActive { get; private set; }

    public virtual ClubMember ClubMember { get; set; }
    // هر مشتری می‌تواند چند حساب کاربری داشته باشد.
    public virtual ICollection<User> Users { get; private set; } = new List<User>();

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
    }

    public void Edit(string name, string economicCode, string phoneNumber, string email, CustomerType type)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Customer name is required.");

        Name = name;
        EconomicCode = economicCode;
        PhoneNumber = phoneNumber;
        Email = email;
        Type = type;
    }
    public void AddUserToCustomer(User user)
    {
        if (user == null)
            throw new ArgumentNullException(nameof(user));

        if (user.Customer != null && user.Customer != this)
            throw new InvalidOperationException("This user is already assigned to another customer.");

        if (user.CustomerId.HasValue && user.CustomerId != Id)
            throw new InvalidOperationException("This user is already assigned to another customer.");

        if (Users.Any(u => u.Id == user.Id))
            throw new InvalidOperationException("This user is already assigned to the customer.");

        Users.Add(user);
    }
    public void ToggleActivation() => IsActive = !IsActive;

}