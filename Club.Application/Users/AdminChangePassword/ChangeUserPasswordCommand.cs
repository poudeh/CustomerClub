using Common.Application;

namespace Club.Application.Users.AdminChangePassword;

public record ChangeUserPasswordCommand(long Id, string Password , string RePassword , bool IsAdmin ) : IBaseCommand;
