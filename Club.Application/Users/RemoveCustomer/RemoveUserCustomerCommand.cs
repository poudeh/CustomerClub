using Common.Application;

namespace Club.Application.Users.RemoveCustomer;

public record RemoveUserCustomerCommand(long Id) : IBaseCommand;
