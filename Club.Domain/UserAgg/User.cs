using Club.Domain.CustomerAgg;
using Club.Domain.UserAgg.Entities;
using Club.Domain.UserAgg.Enums;
using Common.Common.Domain;
namespace Club.Domain.UserAgg;
/// <summary>
/// یوزر ها جدا از اینکه کاربر هستند یا خیر
/// </summary>
public class User:AggregateRoot
{
    public string Username { get; private set; }
    public string PhoneNumber { get; private set; }
    public string PasswordHash { get; private set; }
    public Gender Gender { get; private set; }
    public long? CustomerId { get; private set; }
    public List<UserRole> Roles { get; private set; }
    public bool IsActive { get; private set; }

    public virtual Customer Customer { get; private set; }

    protected User()
    {
        Roles = new List<UserRole>();
    }
    public User( string username,string phoneNumber,Gender? gender,string passwordHash,long? customerId = null)
    {
        Username = username;
        PhoneNumber = phoneNumber;
        PasswordHash = passwordHash;
        CustomerId = customerId;
        Roles = new List<UserRole>();
        IsActive = true;
        Gender = gender ?? Gender.Unknown;
    }

    public void Edit(string username ,string phoneNumber, long customerId)
    {
        if (customerId <= 0)
            throw new ArgumentException("CustomerId is invalid.");
        Username = username;
        PhoneNumber = phoneNumber;
        CustomerId = customerId;

    }
    public void AddRole(UserRole role)
    {
        if (role == null) throw new ArgumentNullException(nameof(role));

        if (Roles.Any(x => x.Role == role.Role)) return;

        Roles.Add(role);
    }

    public void RemoveRole(UserRole role)
    {
        if (role == null)
            throw new ArgumentNullException(nameof(role));
        Roles.RemoveAll(x => x.Role == role.Role);
    }

    public void IllustrateGender(Gender gender)
    {
        if (this.Gender == Gender.Unknown && gender != Gender.Unknown)
                this.Gender = gender;
    } 

    public void ToggleActivation() => IsActive = !IsActive;
    public void ChangePassword(string passwordHash) => PasswordHash = passwordHash;
    public void ClearRoles() => Roles.Clear();
    public void RemoveCustomer() => CustomerId = null;


}
