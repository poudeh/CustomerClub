using Club.Infrastructure.Persistent.Ef;
using Club.Queries.Users.DTOs;
using Common.Common.Query;
using Microsoft.EntityFrameworkCore;

namespace Club.Queries.Users.GetById;

public class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery, UserDto?>
{
    private readonly ClubContext _context;

    public GetUserByIdQueryHandler(ClubContext context)
    {
        _context = context;
    }

    public async Task<UserDto?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(f => f.Id == request.UserId, cancellationToken);
        if (user == null)
            return null;
        return await user.Map().SetUserRoleTitles(_context);
    }
}