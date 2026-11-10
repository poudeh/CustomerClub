using Club.Domain.UserAgg.Enums;
using Common.Application;

namespace Club.Application.Users.Create;

public record CreateUserCommand(string Username,string PhoneNumber,Gender Gender, string PasswordHash, long? CustomerId) : IBaseCommand;
