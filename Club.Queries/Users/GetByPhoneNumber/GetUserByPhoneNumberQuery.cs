using Club.Queries.BaseDtos;
using Club.Queries.Users.DTOs;
using Common.Query;

namespace Club.Queries.Users.GetByPhoneNumber;

public record GetUserByPhoneNumberQuery(string PhoneNumber):IQuery<AuthenticatedUserDto?>;