using Common.Application;

namespace Club.Application.Users.ToggleActivation;

public record ToggleUserActivationCommand(long Id) : IBaseCommand;
