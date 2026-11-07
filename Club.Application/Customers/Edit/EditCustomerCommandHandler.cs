using Club.Domain.CustomerAgg.Repository;
using Common.Application;

namespace Club.Application.Customers.Edit;

public class EditCustomerCommandHandler : IBaseCommandHandler<EditCustomerCommand>
{
    private readonly ICustomerRepository _repository;

    public EditCustomerCommandHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(EditCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await _repository.GetTracking(request.Id);
        if (customer == null)
            return OperationResult.NotFound();

        customer.Edit(
            request.Name,
            request.EconomicCode,
            request.PhoneNumber,
            request.Email,
            request.Type);

        await _repository.Save();
        return OperationResult.Success();
    }
}
