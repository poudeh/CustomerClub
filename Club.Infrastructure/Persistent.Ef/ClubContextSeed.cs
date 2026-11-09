using Club.Domain.ClubMemberAgg;
using Club.Domain.CustomerAgg;
using Club.Domain.CustomerAgg.Enums;
using Club.Domain.LoyaltyAccountAgg;
using Club.Domain.RoleAgg;
using Club.Domain.RoleAgg.Enums;
using Microsoft.EntityFrameworkCore;
namespace Club.Infrastructure.Persistent.Ef;

public static class ClubContextSeed
{
    public static async Task SeedAsync(ClubContext context)
    {
        await SeedCustomers(context);
        await SeedClubMembers(context);
        await SeedLoyaltyAccounts(context);
        await SeedMembershipTiers(context);
        await SeedLoyaltyCampaigns(context);
        await SeedRoles(context);
        await SeedRolePermissions(context);
        await SeedUsers(context);
    }
    private static async Task SeedCustomers(ClubContext context)
    {
        if (await context.customers.AnyAsync())
            return;

        var customers = new List<Customer>
        {
            new Customer(
                "شرکت پارس خودرو",
                "1234567890",
                "411111111111",
                "09121111111",
                "info@parskhodro.com",
                CustomerType.LegalEntity
            ),

            new Customer(
                "شرکت ایران تجارت",
                "1234567891",
                "411111111112",
                "09122222222",
                "info@irantrade.com",
                CustomerType.LegalEntity
            ),

            new Customer(
                "علی محمدی",
                "1234567892",
                "",
                "09123333333",
                "ali@gmail.com",
                CustomerType.Individual
            ),

            new Customer(
                "رضا احمدی",
                "1234567893",
                "",
                "09124444444",
                "reza@gmail.com",
                CustomerType.Individual
            ),

            new Customer(
                "شرکت توسعه تجارت",
                "1234567894",
                "411111111113",
                "09125555555",
                "info@tosee.com",
                CustomerType.LegalEntity
            )
        };

        await context.customers.AddRangeAsync(customers);
        await context.SaveChangesAsync();
    }

    private static async Task SeedClubMembers(ClubContext context)
    {
        if (await context.clubMembers.AnyAsync())
            return;

        var customers = await context.customers
            .OrderBy(x => x.Id)
            .ToListAsync();

        if (!customers.Any())
            return;

        var members = new List<ClubMember>();

        int counter = 1;

        foreach (var customer in customers)
        {
            var member = new ClubMember(
                customer.Id,
                $"CLUB-{counter:0000}"
            );

            members.Add(member);
            counter++;
        }

        await context.clubMembers.AddRangeAsync(members);
        await context.SaveChangesAsync();
    }

    private static async Task SeedLoyaltyAccounts(ClubContext context)
    {
        if (await context.loyaltyAccounts.AnyAsync())
            return;
        var clubMembers = await context.clubMembers
            .OrderBy(x => x.Id)
            .ToListAsync();
        if (!clubMembers.Any())
            return;
        var accounts = new List<LoyaltyAccount>();
        var points = new decimal[]
        {
            0,
            500,
            1200,
            2500,
            5000
        };
        for (int i = 0; i < clubMembers.Count; i++)
        {
            var account = new LoyaltyAccount(clubMembers[i].Id);
            if (i < points.Length && points[i] > 0)
            {
                account.EarnPoints(points[i]);
            }
            accounts.Add(account);
        }
        await context.loyaltyAccounts.AddRangeAsync(accounts);
        await context.SaveChangesAsync();
    }

    private static async Task SeedMembershipTiers(ClubContext context)
    {
        if (await context.MembershipsTiers.AnyAsync())
            return;

        // Insert MembershipTiers
    }

    private static async Task SeedLoyaltyCampaigns(ClubContext context)
    {
        if (await context.LoyaltyCampaigns.AnyAsync())
            return;

        // Insert LoyaltyCampaigns
    }

    private static async Task SeedRoles(ClubContext context)
    {
        if (await context.Roles.AnyAsync())
            return;
        var roles = new List<Role>
        {
            new Role("مدیر سیستم",
                Enum.GetValues<Permission>()
                    .Select(p => new RolePermission(p))
                    .ToList()),

            // مدیر باشگاه
            new Role("مدیر باشگاه", new List<RolePermission>
            {
                new RolePermission(Permission.PanelAdmin),
                new RolePermission(Permission.EditProfile),
                new RolePermission(Permission.ChangePassword),
                new RolePermission(Permission.CRUD_Product),
                new RolePermission(Permission.Order_Management),
                new RolePermission(Permission.Comment_Management),
                new RolePermission(Permission.Category_Management),
                new RolePermission(Permission.Add_Inventory),
                new RolePermission(Permission.Edit_Inventory),
                new RolePermission(Permission.Seller_Management)
            }),

            // اپراتور
            new Role("اپراتور", new List<RolePermission>
            {
                new RolePermission (Permission.PanelAdmin),
                new RolePermission(Permission.EditProfile),
                new RolePermission(Permission.ChangePassword),
                new RolePermission(Permission.Order_Management),
                new RolePermission(Permission.Comment_Management)
            })
        };

        await context.Roles.AddRangeAsync(roles);
        await context.SaveChangesAsync();

        // Insert Roles
    }

    private static async Task SeedRolePermissions(ClubContext context)
    {
        if (await context.RolePermissions.AnyAsync())
            return;

        // Insert RolePermissions
    }

    private static async Task SeedUsers(ClubContext context)
    {
        if (await context.Users.AnyAsync())
            return;

        // Insert Users
    }
}