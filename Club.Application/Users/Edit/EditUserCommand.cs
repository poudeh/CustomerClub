using Common.Application;

namespace Club.Application.Users.Edit;

public record EditUserCommand(long Id, string Username,string PhoneNumber, long? CustomerId) : IBaseCommand;
