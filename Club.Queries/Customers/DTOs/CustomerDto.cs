using Club.Domain.CustomerAgg.Enums;
using Common.Query;
namespace Club.Queries.Customers.DTOs;

public class CustomerDto : BaseDto
{
    public string Name { get; set; }
    public string NationalId { get; set; }
    public string EconomicCode { get;set; }
    public string PhoneNumber { get;set; }
    public string Email { get;set; }
    public CustomerType Type { get;set; }
    public bool IsActive { get;set; }

}