using Club.Domain.CustomerAgg.Repository;
using Club.Domain.UserAgg.Repository;
using Common.Application;
using Common.Common.Application;

namespace Club.Application.Customers.AddUserToCustomer;

public class AddUserToCustomerCommandHandler : IBaseCommandHandler<AddUserToCustomerCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly ICustomerRepository _customerRepository;
    public AddUserToCustomerCommandHandler(IUserRepository userRepository, ICustomerRepository customerRepository)
    {
        _userRepository = userRepository;
        _customerRepository = customerRepository;
    }

    public async Task<OperationResult> Handle(AddUserToCustomerCommand request, CancellationToken cancellationToken)
    {

        var user = await _userRepository.GetTracking(request.UserId);
        if (user == null)
            return OperationResult.NotFound("کاربر یافت نشد");
        var customer = await _customerRepository.GetTracking(request.UserId);
        if (customer == null)
            return OperationResult.NotFound("مشتری یافت نشد");
        customer.AddUserToCustomer(user);
        await _customerRepository.Save();
        return OperationResult.Success();
    }
}