using Common.Application;

namespace Club.Application.Users.Create;

public record CreateUserCommand(string Username,string PhoneNumber, string PasswordHash, long? CustomerId) : IBaseCommand;
