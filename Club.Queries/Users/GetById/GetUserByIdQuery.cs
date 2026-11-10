using Club.Queries.Users.DTOs;
using Common.Query;
namespace Club.Queries.Users.GetById;

public class GetUserByIdQuery : IQuery<UserDto?>
{
    public GetUserByIdQuery(long userId)
    {
        UserId = userId;
    }

    public long UserId { get; private set; }
}