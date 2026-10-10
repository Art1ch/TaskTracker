using Microsoft.Extensions.DependencyInjection;
using System;
using TaskTrackerDesktop.Core.Interfaces;
using TaskTrackerDesktop.Infrastructure.Implementations;
using TaskTrackerDesktop.Infrastructure.Settings;
using TaskTrackerDesktop.Infrastructure.DelegatingHandlers;
using TaskTrackerDesktop.Infrastructure.Helpers;

namespace TaskTrackerDesktop.Infrastructure;

public static class Injection
{
    public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, ApiSettings apiSettings)
    {
        return services.AddImplementations(apiSettings);
    }

    private static IServiceCollection AddImplementations(this IServiceCollection services, ApiSettings apiSettings)
    {
        services.AddSingleton<TokenStorageHelper>();
        services.AddTransient<AuthDelegatingHandler>();

        services.AddHttpClient<IAuthService, HttpAuthService>(client =>
        {
            client.BaseAddress = new Uri(apiSettings.BaseUrl);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
        });

        services.AddHttpClient<IUserService, HttpUserService>(client =>
        {
            client.BaseAddress = new Uri(apiSettings.BaseUrl);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
        })
        .AddHttpMessageHandler<AuthDelegatingHandler>();

        services.AddHttpClient<IProcessService, HttpProcessService>(client =>
        {
            client.BaseAddress = new Uri(apiSettings.BaseUrl);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
        })
        .AddHttpMessageHandler<AuthDelegatingHandler>();

        services.AddHttpClient<ITaskService, HttpTaskService>(client =>
        {
            client.BaseAddress = new Uri(apiSettings.BaseUrl);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
        })
        .AddHttpMessageHandler<AuthDelegatingHandler>();

        services.AddHttpClient<IRemarkService, HttpRemarkService>(client =>
        {
            client.BaseAddress = new Uri(apiSettings.BaseUrl);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
        })
        .AddHttpMessageHandler<AuthDelegatingHandler>();

        return services;
    }
}
