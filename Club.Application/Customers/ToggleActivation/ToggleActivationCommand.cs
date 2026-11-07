using Common.Application;

namespace Club.Application.Customers.ToggleActivation;

public record ToggleActivationCommand(long customerId):IBaseCommand;