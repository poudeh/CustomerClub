using Club.Domain.LoyaltyAccountAgg;
using Club.Domain.LoyaltyAccountAgg.Repository;
using Common.Application;
namespace Club.Application.LoyaltyAccounts.Create;

public class CreateLoyaltyAccountCommandHandler : IBaseCommandHandler<CreateLoyaltyAccountCommand>
{
    private readonly ILoyaltyAccountRepository _repository;

    public CreateLoyaltyAccountCommandHandler(ILoyaltyAccountRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(CreateLoyaltyAccountCommand request, CancellationToken cancellationToken)
    {
        var account = new LoyaltyAccount(request.ClubMemberId);
        await _repository.AddAsync(account);
        await _repository.Save();
        return OperationResult.Success();
    }
}
