using Club.Domain.LoyaltyAccountAgg.Repository;
using Common.Application;

namespace Club.Application.LoyaltyAccounts.RefundPoints;

public class RefundPointsCommandHandler : IBaseCommandHandler<RefundPointsCommand>
{
    private readonly ILoyaltyAccountRepository _repository;

    public RefundPointsCommandHandler(ILoyaltyAccountRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(RefundPointsCommand request, CancellationToken cancellationToken)
    {
        var account = await _repository.GetTracking(request.Id);
        if (account == null)
            return OperationResult.NotFound();

        account.RefundPoints(request.Points);
        await _repository.Save();

        return OperationResult.Success();
    }
}
