using Club.Domain.UserAgg.Enums;
using Common.Query;
using Common.Query.Filter;

namespace Club.Queries.Users.DTOs;

public class UserFilterData :BaseDto
{
    public string Username { get;  set; }
    public string PhoneNumber { get;  set; }
    public Gender Gender { get;  set; }
    public bool IsActive { get;  set; }


}

public class UserFilterParams : BaseFilterParam
{
    public string? Username { get; set; }
    public string? PhoneNumber { get; set; }
    public long? Id { get; set; }
}

public class UserFilterResult : BaseFilter<UserFilterData, UserFilterParams>
{

}