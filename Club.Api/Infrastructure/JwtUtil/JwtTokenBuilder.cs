using Club.Queries.BaseDtos;
using Club.Queries.Users.DTOs;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Club.Queries.ClubMembers.DTOs;
using Club.Queries.Customers.DTOs;
namespace Club.Api.Infrastructure.JwtUtil;

public class JwtTokenBuilder
{
    public static string BuildToken(AuthenticatedUserDto authenticatedUser, IConfiguration configuration)
    {
        UserDto user = authenticatedUser.UserDto;
        CustomerDto? customer = authenticatedUser.CustomerDto;
        ClubMemberDto? clubMember = authenticatedUser.ClubMemberDto;

        var claims = new List<Claim>
        {
            new(ClaimTypes.MobilePhone, user.PhoneNumber),
            new(ClaimTypes.NameIdentifier, user.Id.ToString())
        };

        // Roles
        foreach (var role in user.Roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role.RoleTitle));
        }

        // Customer Claims
        if (customer != null)
        {
            claims.Add(new Claim(CustomClaimTypes.Customer_Name, customer.Name));
            claims.Add(new Claim(CustomClaimTypes.Customer_Type, customer.Type.ToString()));
        }

        // ClubMember Claims
        if (clubMember != null)
        {
            claims.Add(new Claim(CustomClaimTypes.ClubMember_MemberCode, clubMember.MemberCode));
            claims.Add(new Claim(CustomClaimTypes.ClubMember_MemberStatus, clubMember.Status.ToString()));
        }

        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtConfig:SignInKey"]!));

        var credential = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: configuration["JwtConfig:Issuer"],
            audience: configuration["JwtConfig:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddDays(7),
            signingCredentials: credential);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}