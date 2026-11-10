using Club.Queries.Customers.DTOs;
using Common.Query;

namespace Club.Queries.Customers.GetByFilter;

public class GetCustomerByFilterQuery : QueryFilter<CustomerFilterResult , CustomerFilterParams>
{
    public GetCustomerByFilterQuery(CustomerFilterParams filterParams) : base(filterParams)
    {
    }
}