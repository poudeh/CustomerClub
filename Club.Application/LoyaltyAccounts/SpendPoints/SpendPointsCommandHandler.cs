using Club.Domain.LoyaltyAccountAgg.Repository;
using Common.Application;
using Common.Common.Application;

namespace Club.Application.LoyaltyAccounts.SpendPoints;

public class SpendPointsCommandHandler : IBaseCommandHandler<SpendPointsCommand>
{
    private readonly ILoyaltyAccountRepository _repository;

    public SpendPointsCommandHandler(ILoyaltyAccountRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(SpendPointsCommand request, CancellationToken cancellationToken)
    {
        var account = await _repository.GetTracking(request.Id);
        if (account == null)
            return OperationResult.NotFound();

        account.SpendPoints(request.Points);
        await _repository.Save();

        return OperationResult.Success();
    }
}
