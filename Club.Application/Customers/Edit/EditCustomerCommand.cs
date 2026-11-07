using Club.Domain.CustomerAgg.Enums;
using Common.Application;

namespace Club.Application.Customers.Edit;

public record EditCustomerCommand(long Id, string Name, string EconomicCode, string PhoneNumber, string Email,
    CustomerType Type) : IBaseCommand;
