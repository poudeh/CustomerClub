using Club.Domain.ClubMemberAgg;
using Club.Domain.CustomerAgg;
using Club.Domain.LoyaltyAccountAgg;
using Club.Domain.LoyaltyCampaignAgg;
using Club.Domain.MembershipTierAgg;
using Club.Domain.RoleAgg;
using Club.Domain.UserAgg;
using Common.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure._Utilities.MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Common.Common.Domain;

namespace Club.Infrastructure.Persistent.Ef;

public class ClubContext : DbContext
{
    private readonly ICustomPublisher _publisher;
    public ClubContext(DbContextOptions<ClubContext> options, ICustomPublisher publisher) : base(options)
    {
        _publisher = publisher;
    }
    public DbSet<ClubMember> clubMembers { get; set; }
    public DbSet<Customer> customers { get; set; }
    public DbSet<LoyaltyAccount> loyaltyAccounts { get; set; }
    public DbSet<LoyaltyCampaign> LoyaltyCampaigns { get; set; }
    public DbSet<MembershipTier> MembershipsTiers { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<RolePermission> RolePermissions { get; set; }
    public DbSet<User> Users { get; set; }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        var modifiedEntities = GetModifiedEntities();
        await PublishEvents(modifiedEntities);
        return await base.SaveChangesAsync(cancellationToken);
    }
    private List<AggregateRoot> GetModifiedEntities() =>
        ChangeTracker.Entries<AggregateRoot>()
            .Where(x => x.State != EntityState.Detached)
            .Select(c => c.Entity)
            .Where(c => c.DomainEvents.Any()).ToList();

    private async Task PublishEvents(List<AggregateRoot> modifiedEntities)
    {
        foreach (var entity in modifiedEntities)
        {
            var events = entity.DomainEvents;
            foreach (var domainEvent in events)
            {
                await _publisher.Publish(domainEvent, PublishStrategy.ParallelNoWait);
            }
        }
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClubContext).Assembly);
        base.OnModelCreating(modelBuilder);

    }
}
