using Club.Domain.UserAgg.Repository;
using Common.Application;
using Common.Common.Application;

namespace Club.Application.Users.ClearRoles;

public class ClearUserRolesCommandHandler : IBaseCommandHandler<ClearUserRolesCommand>
{
    private readonly IUserRepository _repository;

    public ClearUserRolesCommandHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(ClearUserRolesCommand request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetTracking(request.Id);
        if (user == null)
            return OperationResult.NotFound();
        user.ClearRoles();
        await _repository.Save();
        return OperationResult.Success();
    }
}
