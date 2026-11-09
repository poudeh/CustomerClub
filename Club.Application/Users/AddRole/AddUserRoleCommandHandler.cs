using Club.Domain.UserAgg.Entities;
using Club.Domain.UserAgg.Repository;
using Common.Application;

namespace Club.Application.Users.AddRole;

public class AddUserRoleCommandHandler : IBaseCommandHandler<AddUserRoleCommand>
{
    private readonly IUserRepository _repository;

    public AddUserRoleCommandHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(AddUserRoleCommand request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetTracking(request.UserId);
        if (user == null)
            return OperationResult.NotFound();

        var role = new UserRole(request.RoleId);
        user.AddRole(role);
        await _repository.Save();

        return OperationResult.Success();
    }
}
