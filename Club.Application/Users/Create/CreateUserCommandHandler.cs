using Club.Domain.UserAgg;
using Club.Domain.UserAgg.Repository;
using Common.Application;
using Common.Common.Application;

namespace Club.Application.Users.Create;

public class CreateUserCommandHandler : IBaseCommandHandler<CreateUserCommand>
{
    private readonly IUserRepository _repository;
    public CreateUserCommandHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User(username:request.Username, phoneNumber:request.PhoneNumber, 
            passwordHash:request.PasswordHash ,
            gender:request.Gender, customerId:request.CustomerId);

        await _repository.AddAsync(user);
        await _repository.Save();
        return OperationResult.Success();
    }
}
