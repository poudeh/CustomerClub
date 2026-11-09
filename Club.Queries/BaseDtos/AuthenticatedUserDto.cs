using Club.Queries.ClubMembers.DTOs;
using Club.Queries.Customers.DTOs;
using Club.Queries.Users.DTOs;

namespace Club.Queries.BaseDtos;

public class AuthenticatedUserDto
{
    public UserDto UserDto { get; set; } = new ();
    public CustomerDto? CustomerDto { get; set; } = new ();
    public ClubMemberDto? ClubMemberDto { get; set; } = new ();

}