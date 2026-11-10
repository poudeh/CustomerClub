using Club.Domain.UserAgg.Repository;
using Common.Application;
using Common.Common.Application;

namespace Club.Application.Users.RemoveCustomer;

public class RemoveUserCustomerCommandHandler : IBaseCommandHandler<RemoveUserCustomerCommand>
{
    private readonly IUserRepository _repository;

    public RemoveUserCustomerCommandHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(RemoveUserCustomerCommand request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetTracking(request.Id);
        if (user == null)
            return OperationResult.NotFound();

        user.RemoveCustomer();
        await _repository.Save();

        return OperationResult.Success();
    }
}
