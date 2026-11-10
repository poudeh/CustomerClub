using Club.Domain.UserAgg.Enums;
using Common.Application;

namespace Club.Application.Users.Register;

public record RegisterUserCommand(string UserName , string PhoneNumber ,Gender? gender ,string Password , long? customerId):IBaseCommand;