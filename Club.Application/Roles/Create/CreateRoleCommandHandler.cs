using Club.Domain.RoleAgg;
using Club.Domain.RoleAgg.Repository;
using Common.Application;
namespace Club.Application.Roles.Create;

public class CreateRoleCommandHandler:IBaseCommandHandler<CreateRoleCommand>
{
    private readonly IRoleRepository _repository;

    public CreateRoleCommandHandler(IRoleRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        var permissions = new List<RolePermission>();
        request.Permissions.ForEach(f =>
        {
            permissions.Add(new RolePermission(f));
        });
        var role = new Role(request.Title, permissions);
        await _repository.AddAsync(role);
        await _repository.Save();
        return OperationResult.Success();
    }
}