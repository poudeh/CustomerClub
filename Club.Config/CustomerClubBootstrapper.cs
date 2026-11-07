using Club.Application.Roles.Create;
using Common.Common.Application.Pipelines;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Club.Config;

public static class CustomerClubBootstrapper
{
    public static void RegisterCustomerDependency(this IServiceCollection service, string connectionString)
    {
        service.AddTransient(typeof(IPipelineBehavior<,>), typeof(ExceptionBehavior<,>));

        service.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        service.AddMediatR(typeof(CreateRoleCommand).Assembly);



    }
    
}