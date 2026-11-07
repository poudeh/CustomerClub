using Club.Domain.CustomerAgg;
using Club.Domain.CustomerAgg.Repository;
using Common.Application;

namespace Club.Application.Customers.Create;

public class CreateCustomerCommandHandler : IBaseCommandHandler<CreateCustomerCommand>
{
    private readonly ICustomerRepository _repository;

    public CreateCustomerCommandHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = new Customer(
            request.Name,
            request.NationalId,
            request.EconomicCode,
            request.PhoneNumber,
            request.Email,
            request.Type);

        await _repository.AddAsync(customer);
        await _repository.Save();

        return OperationResult.Success();
    }
}
