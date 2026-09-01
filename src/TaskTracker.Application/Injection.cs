using FluentValidation;
using Mapster;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TaskTracker.Application.PipelineBehaviors;

namespace TaskTracker.Application;

public static class Injection
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        return services
            .AddValidators()
            .AddMediator()
            .AddPipelineBehaviors()
            .AddMapping();
    }

    private static IServiceCollection AddMediator(this IServiceCollection services)
    {
        return services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });
    }

    private static IServiceCollection AddValidators(this IServiceCollection services) =>
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly(), ServiceLifetime.Scoped);

    private static IServiceCollection AddPipelineBehaviors(this IServiceCollection services) =>
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

    private static IServiceCollection AddMapping(this IServiceCollection services)
    {
        services.AddMapster();

        return services;
    }
}
