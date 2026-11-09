using Club.Domain.UserAgg.Repository;
using Common.Application;

namespace Club.Application.Users.Edit;

public class EditUserCommandHandler : IBaseCommandHandler<EditUserCommand>
{
    private readonly IUserRepository _repository;

    public EditUserCommandHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(EditUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetTracking(request.Id);
        if (user == null)
            return OperationResult.NotFound();

        user.Edit(request.Username, request.PhoneNumber,request.CustomerId ?? 0);
        await _repository.Save();

        return OperationResult.Success();
    }
}
