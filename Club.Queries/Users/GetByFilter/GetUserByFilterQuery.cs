using Club.Queries.Users.DTOs;
using Common.Query;

namespace Club.Queries.Users.GetByFilter;

public class GetUserByFilterQuery :QueryFilter<UserFilterResult , UserFilterParams>
{
    public GetUserByFilterQuery(UserFilterParams filterParams) : base(filterParams)
    {
    }
}