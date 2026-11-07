using Club.Domain.ClubMemberAgg.Enums;
using Club.Domain.ClubMemberAgg.Repository;
using Club.Domain.CustomerAgg.Repository;
using Common.Application;
namespace Club.Application.Customers.ToggleActivation;

public class ToggleActivationCommandHandler : IBaseCommandHandler<ToggleActivationCommand>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IClubMemberRepository _clubMemberRepository;
    public ToggleActivationCommandHandler(ICustomerRepository customerRepository, IClubMemberRepository clubMemberRepository)
    {
        _customerRepository = customerRepository;
        _clubMemberRepository = clubMemberRepository;
    }
    public async Task<OperationResult> Handle(ToggleActivationCommand request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetTracking(request.customerId);
        if (customer == null)
            return OperationResult.NotFound();
        customer.ToggleActivation();
        var clubMember = await _clubMemberRepository.GetClubMemberByCustomer(customer.Id);
        if (clubMember != null)
        {
            clubMember.ChangeStatus(customer.IsActive ? MemberStatus.Active : MemberStatus.Suspended);
        }
        await _customerRepository.Save();
        return OperationResult.Success();
    }
}