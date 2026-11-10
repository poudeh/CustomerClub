using Club.Domain.UserAgg;
using Club.Infrastructure.Persistent.Ef;
using Club.Queries.Users.DTOs;
using Common.Common.Query;
using Microsoft.EntityFrameworkCore;

namespace Club.Queries.Users.GetByFilter;

public class GetUserByFilterQueryHandler : IQueryHandler<GetUserByFilterQuery , UserFilterResult>
{
    private readonly ClubContext _context;
    public GetUserByFilterQueryHandler(ClubContext context)
    {
        _context = context;
    }
    public async Task<UserFilterResult> Handle(GetUserByFilterQuery request, CancellationToken cancellationToken)
    {
        var @params = request.FilterParams;
        IQueryable<User> result = _context.Users.OrderByDescending(d => d.Id).AsQueryable();

        if (!string.IsNullOrWhiteSpace(@params.Username))
            result = result.Where(r => r.Username.Contains(@params.Username));

        if (!string.IsNullOrWhiteSpace(@params.PhoneNumber))
            result = result.Where(r => r.PhoneNumber.Contains(@params.PhoneNumber));

        if (@params.Id != null)
            result = result.Where(r => r.Id == @params.Id);

        var skip = (@params.PageId - 1) * @params.Take;
        var model = new UserFilterResult()
        {
            Data = await result.Skip(skip).Take(@params.Take)
                .Select(user => user.MapFilterData()).ToListAsync(cancellationToken),
            FilterParams = @params
        };
        model.GeneratePaging(result, @params.Take, @params.PageId);
        return model;

    }
}