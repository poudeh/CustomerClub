using Club.Application.Roles.Create;
using Club.Infrastructure;
using Club.Queries.Roles.GetById;
using Common.Common.Application.Pipelines;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Club.Config;

public static class CustomerClubBootstrapper
{
    public static void RegisterCustomerDependency(this IServiceCollection service, string connectionString)
    {
        InfrastructureBootstrapper.Init(service, connectionString);
        service.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(
                typeof(CreateRoleCommand).Assembly);
            cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
            cfg.AddOpenBehavior(typeof(ExceptionBehavior<,>));
        });

        service.AddMediatR(a =>
        {
            a.RegisterServicesFromAssembly(typeof(GetRoleByIdQuery).Assembly);
        });

    }

}