using Club.Domain.CustomerAgg.Enums;
using Common.Application;

namespace Club.Application.Customers.Create;

public record CreateCustomerCommand(
    string Name,
    string NationalId,
    string EconomicCode,
    string PhoneNumber,
    string Email,
    CustomerType Type) : IBaseCommand;
