using Club.Infrastructure.Persistent.Ef;
using Club.Queries.BaseDtos;
using Club.Queries.ClubMembers.DTOs;
using Club.Queries.Customers.DTOs;
using Club.Queries.Users.DTOs;
using Common.Common.Query;
using Microsoft.EntityFrameworkCore;
namespace Club.Queries.Users.GetByPhoneNumber;

public class GetUserByPhoneNumberQueryHandler : IQueryHandler<GetUserByPhoneNumberQuery, AuthenticatedUserDto?>
{
    private readonly ClubContext context;
    public GetUserByPhoneNumberQueryHandler(ClubContext context)
    {
        this.context = context;
    }

    public async Task<AuthenticatedUserDto?> Handle(GetUserByPhoneNumberQuery request, CancellationToken cancellationToken)
    {
        return await context.Users
            .AsNoTracking().Where(user => user.PhoneNumber == request.PhoneNumber)
            .Select(user => new AuthenticatedUserDto
            {
                UserDto = new UserDto
                {
                    Id = user.Id,
                    Username = user.Username,
                    PasswordHash = user.PasswordHash,
                    IsActive = user.IsActive,
                    Roles = user.Roles.Select(role => new UserRoleDto
                    {
                        RoleId = role.RoleId,
                        RoleTitle = role.Role.Title
                    }).ToList()
                },
                CustomerDto = new CustomerDto
                {
                    Id = user.Customer.Id,
                    NationalId = user.Customer.NationalId,
                    EconomicCode = user.Customer.EconomicCode,
                    PhoneNumber = user.Customer.PhoneNumber,
                    Email = user.Customer.Email,
                    Type = user.Customer.Type,
                    IsActive = user.Customer.IsActive
                },
                ClubMemberDto = new ClubMemberDto
                {
                    Id = user.Customer.ClubMember.Id,
                    MemberCode = user.Customer.ClubMember.MemberCode,
                    Status = user.Customer.ClubMember.Status
                }
            }).FirstOrDefaultAsync(cancellationToken);
    }
}