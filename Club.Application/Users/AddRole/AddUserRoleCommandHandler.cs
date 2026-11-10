using Club.Domain.UserAgg.Entities;
using Club.Domain.UserAgg.Repository;
using Common.Application;
using Common.Common.Application;

namespace Club.Application.Users.AddRole;

public class AddUserRoleCommandHandler(IUserRepository repository) : IBaseCommandHandler<AddUserRoleCommand>
{
    public async Task<OperationResult> Handle(AddUserRoleCommand request, CancellationToken cancellationToken)
    {
        var user = await repository.GetTracking(request.UserId);
        if (user == null) return OperationResult.NotFound();

        var role = new UserRole(request.RoleId);
        user.AddRole(role);
        await repository.Save();
        return OperationResult.Success();
    }
}
