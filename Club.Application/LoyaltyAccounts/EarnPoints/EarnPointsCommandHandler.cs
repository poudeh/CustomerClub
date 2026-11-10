using Club.Domain.LoyaltyAccountAgg.Repository;
using Common.Application;
using Common.Common.Application;

namespace Club.Application.LoyaltyAccounts.EarnPoints;

public class EarnPointsCommandHandler : IBaseCommandHandler<EarnPointsCommand>
{
    private readonly ILoyaltyAccountRepository _repository;

    public EarnPointsCommandHandler(ILoyaltyAccountRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(EarnPointsCommand request, CancellationToken cancellationToken)
    {
        var account = await _repository.GetTracking(request.Id);
        if (account == null)
            return OperationResult.NotFound();

        account.EarnPoints(request.Points);
        await _repository.Save();

        return OperationResult.Success();
    }
}
