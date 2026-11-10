using Club.Domain.CustomerAgg;
using Club.Infrastructure.Persistent.Ef;
using Club.Queries.Customers.DTOs;
using Common.Common.Query;
using Microsoft.EntityFrameworkCore;

namespace Club.Queries.Customers.GetByFilter;

public class GetCustomerByFilterQueryHandler : IQueryHandler<GetCustomerByFilterQuery, CustomerFilterResult>
{
    private readonly ClubContext _context;

    public GetCustomerByFilterQueryHandler(ClubContext context)
    {
        _context = context;
    }

    public async Task<CustomerFilterResult> Handle(GetCustomerByFilterQuery request, CancellationToken cancellationToken)
    {
        var @params = request.FilterParams;

        IQueryable<Customer> result = _context.customers.OrderByDescending(x => x.Id).AsQueryable();

        if (!string.IsNullOrWhiteSpace(@params.Name))
            result = result.Where(x => x.Name.Contains(@params.Name));

        if (!string.IsNullOrWhiteSpace(@params.NationalId))
            result = result.Where(x => x.NationalId.Contains(@params.NationalId));

        if (!string.IsNullOrWhiteSpace(@params.EconomicCode))
            result = result.Where(x => x.EconomicCode.Contains(@params.EconomicCode));

        if (@params.Type != 0 && @params.Type.HasValue)
            result = result.Where(x => x.Type == @params.Type);
        if (@params.IsActive.HasValue)
            result = result.Where(x => x.IsActive == @params.IsActive);
        

        var skip = (@params.PageId - 1) * @params.Take;

        var model = new CustomerFilterResult()
        {
            Data = await result.Skip(skip).Take(@params.Take)
                .Select(customer => customer.MapFilterData()).ToListAsync(cancellationToken),
            FilterParams = @params
        };

        model.GeneratePaging(result, @params.Take, @params.PageId);
        return model;


    }
}