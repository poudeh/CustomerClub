using Club.Domain.RoleAgg;
using Club.Domain.RoleAgg.Repository;
using Common.Application;

namespace Club.Application.Roles.Edit;

public class EditRoleCommandHandler(IRoleRepository repository) : IBaseCommandHandler<EditRoleCommand>
{
    public async Task<OperationResult> Handle(EditRoleCommand request, CancellationToken cancellationToken)
    {
        var role = await repository.GetTracking(request.Id);
        if (role == null)
            return OperationResult.NotFound();
        role.Edit(request.Title);
        var permissions = new List<RolePermission>();
        request.Permissions.ForEach(f =>
        {
            permissions.Add(new RolePermission(f));
        });
        role.SetPermissions(permissions);
        await repository.Save();
        return OperationResult.Success();
    }
}