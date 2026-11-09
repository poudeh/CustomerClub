using Club.Domain.ClubMemberAgg.Repository;
using Club.Domain.CustomerAgg.Repository;
using Club.Domain.LoyaltyAccountAgg.Repository;
using Club.Domain.LoyaltyCampaignAgg.Repository;
using Club.Domain.MembershipTierAgg.Repository;
using Club.Domain.RoleAgg.Repository;
using Club.Domain.UserAgg.Repository;
using Club.Infrastructure._Utilities.MediatR;
using Club.Infrastructure.Persistent.Ef;
using Club.Infrastructure.Persistent.Ef.ClubMemberAgg;
using Club.Infrastructure.Persistent.Ef.CustomerAgg;
using Club.Infrastructure.Persistent.Ef.LoyaltyAccountAgg;
using Club.Infrastructure.Persistent.Ef.LoyaltyCampaignAgg;
using Club.Infrastructure.Persistent.Ef.MembershipTierAgg;
using Club.Infrastructure.Persistent.Ef.RoleAgg;
using Club.Infrastructure.Persistent.Ef.UserAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Club.Infrastructure;

public class InfrastructureBootstrapper
{
    public static void Init(IServiceCollection services, string connectionString)
    {
        services.AddDbContext<ClubContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });
        services.AddScoped<ICustomPublisher, CustomPublisher>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IMembershipTierRepository, MembershipTierRepository>();
        services.AddScoped<ILoyaltyCampaignRepository, LoyaltyCampaignRepository>();
        services.AddScoped<ILoyaltyAccountRepository, LoyaltyAccountRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IClubMemberRepository, ClubMemberRepository>();
    }
}