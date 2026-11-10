using Common.Application;

namespace Club.Application.Customers.AddUserToCustomer;

public record AddUserToCustomerCommand(int UserId , int CustomerId):IBaseCommand;