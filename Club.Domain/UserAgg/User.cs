using Club.Domain.UserAgg.Entities;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Club.Domain.UserAgg;
/// <summary>
/// یوزر ها جدا از اینکه کاربر هستند یا خیر
/// </summary>
public class User:AggregateRoot
{
    public string Username { get; private set; }
    public string PasswordHash { get; private set; }
    public long? CustomerId { get; private set; }
    public List<UserRole> Roles { get; private set; }
    public bool IsActive { get; private set; }

    protected User()
    {
        Roles = new List<UserRole>();
    }
    public User( string username,string passwordHash,long? customerId = null)
    {
        Username = username;
        PasswordHash = passwordHash;
        CustomerId = customerId;
        Roles = new List<UserRole>();
        IsActive = true;
    }

    public void ChangeUsername(string username)
    {
        Username = username;
    }

    public void ChangePassword(string passwordHash)
    {
        PasswordHash = passwordHash;
    }

    public void AssignCustomer(long customerId)
    {
        if (customerId <= 0)
            throw new ArgumentException("CustomerId is invalid.");

        CustomerId = customerId;
    }

    public void AddRole(UserRole role)
    {
        if (role == null)
            throw new ArgumentNullException(nameof(role));

        if (Roles.Any(x => x.Role == role.Role))
            return;

        Roles.Add(role);
    }

    public void RemoveRole(UserRole role)
    {
        if (role == null)
            throw new ArgumentNullException(nameof(role));

        Roles.RemoveAll(x => x.Role == role.Role);
    }

    public void ClearRoles() => Roles.Clear();
    public void Activate() => IsActive = true;
    public void Deactivate() => IsActive = false;
    public void RemoveCustomer() => CustomerId = null;


}
