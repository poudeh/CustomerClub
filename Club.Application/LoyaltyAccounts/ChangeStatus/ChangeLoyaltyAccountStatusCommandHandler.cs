using Club.Domain.LoyaltyAccountAgg.Repository;
using Common.Application;
using Common.Common.Application;

namespace Club.Application.LoyaltyAccounts.ChangeStatus;

public class ChangeLoyaltyAccountStatusCommandHandler : IBaseCommandHandler<ChangeLoyaltyAccountStatusCommand>
{
    private readonly ILoyaltyAccountRepository _repository;
    public ChangeLoyaltyAccountStatusCommandHandler(ILoyaltyAccountRepository repository)
    {
        _repository = repository;
    }
    public async Task<OperationResult> Handle(ChangeLoyaltyAccountStatusCommand request, CancellationToken cancellationToken)
    {
        var account = await _repository.GetTracking(request.Id);
        if (account == null)
            return OperationResult.NotFound();
        account.ChangeStatus(request.Status);
        await _repository.Save();
        return OperationResult.Success();
    }
}
