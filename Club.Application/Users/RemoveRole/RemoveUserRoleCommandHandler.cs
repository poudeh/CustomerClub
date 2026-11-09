using Club.Domain.UserAgg.Entities;
using Club.Domain.UserAgg.Repository;
using Common.Application;

namespace Club.Application.Users.RemoveRole;

public class RemoveUserRoleCommandHandler : IBaseCommandHandler<RemoveUserRoleCommand>
{
    private readonly IUserRepository _repository;

    public RemoveUserRoleCommandHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(RemoveUserRoleCommand request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetTracking(request.UserId);
        if (user == null)
            return OperationResult.NotFound();

        var role = user.Roles.FirstOrDefault(x => x.RoleId == request.RoleId);
        if (role == null)
            return OperationResult.NotFound();

        user.RemoveRole(role);
        await _repository.Save();

        return OperationResult.Success();
    }
}
