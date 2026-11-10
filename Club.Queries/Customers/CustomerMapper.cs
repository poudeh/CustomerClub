using Club.Domain.CustomerAgg;
using Club.Queries.Customers.DTOs;

namespace Club.Queries.Customers;

public static class CustomerMapper
{
    public static CustomerFilterData MapFilterData(this Customer customer)
    {
        return new CustomerFilterData()
        {
            Id = customer.Id,
            Name = customer.Name,
            NationalId = customer.NationalId,
            EconomicCode = customer.EconomicCode,
            PhoneNumber = customer.PhoneNumber,
            Email = customer.Email,
            Type = customer.Type,
            IsActive = customer.IsActive
        };
    }
}