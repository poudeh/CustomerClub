using Club.Domain.CustomerAgg;
using Club.Domain.CustomerAgg.Repository;
using Club.Infrastructure._Utilities;

namespace Club.Infrastructure.Persistent.Ef.CustomerAgg;

public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
{
    public CustomerRepository(ClubContext context) : base(context)
    {
    }
}