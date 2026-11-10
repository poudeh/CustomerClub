using Club.Domain.LoyaltyAccountAgg.Repository;
using Common.Application;
using Common.Common.Application;

namespace Club.Application.LoyaltyAccounts.AdjustPoints;

public class AdjustPointsCommandHandler : IBaseCommandHandler<AdjustPointsCommand>
{
    private readonly ILoyaltyAccountRepository _repository;

    public AdjustPointsCommandHandler(ILoyaltyAccountRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(AdjustPointsCommand request, CancellationToken cancellationToken)
    {
        var account = await _repository.GetTracking(request.Id);
        if (account == null)
            return OperationResult.NotFound();

        account.AdjustPoints(request.Points);
        await _repository.Save();

        return OperationResult.Success();
    }
}
