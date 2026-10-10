using Microsoft.Extensions.DependencyInjection;
using Mapster;
using TaskTrackerDesktop.Core.ViewModels;

namespace TaskTrackerDesktop.Core;

public static class Injection
{
    public static IServiceCollection AddCoreLayer(this IServiceCollection services)
    {
        return services
            .AddMapping()
            .AddViewModels();
    }

    private static IServiceCollection AddViewModels(this IServiceCollection services)
    {
        return services
            .AddTransient<MainWindowViewModel>()
            .AddTransient<LoginPageViewModel>()
            .AddTransient<RegisterPageViewModel>()
            .AddTransient<ProcessesPageViewModel>()
            .AddTransient<UsersPageViewModel>()
            .AddTransient<TasksPageViewModel>()
            .AddTransient<DashboardPageViewModel>()
            .AddTransient<TaskDetailPageViewModel>();
    }

    private static IServiceCollection AddMapping(this IServiceCollection services)
    {
        services.AddMapster();

        return services;
    }
}
