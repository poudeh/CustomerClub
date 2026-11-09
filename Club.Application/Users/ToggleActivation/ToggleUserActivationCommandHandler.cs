using Club.Domain.CustomerAgg.Repository;
using Club.Domain.UserAgg.Repository;
using Common.Application;

namespace Club.Application.Users.ToggleActivation;

public class ToggleUserActivationCommandHandler : IBaseCommandHandler<ToggleUserActivationCommand>
{
    private readonly IUserRepository _repository;
    private readonly ICustomerRepository _customerRepository;

    public ToggleUserActivationCommandHandler(IUserRepository repository, ICustomerRepository customerRepository)
    {
        _repository = repository;
        _customerRepository = customerRepository;
    }

    public async Task<OperationResult> Handle(ToggleUserActivationCommand request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetTracking(request.Id);
        if (user == null)
            return OperationResult.NotFound();

        user.ToggleActivation();
        await _repository.Save();

        return OperationResult.Success();
    }
}
