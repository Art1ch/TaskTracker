using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.UI.Xaml;
using System;
using TaskTrackerDesktop.Core;
using TaskTrackerDesktop.Core.Interfaces;
using TaskTrackerDesktop.Infrastructure;
using TaskTrackerDesktop.Infrastructure.Settings;
using TaskTrackerDesktop.WinUI.Implementations;
using TaskTrackerDesktop.WinUI.Windows;

namespace TaskTrackerDesktop.WinUI;

public partial class App : Application
{
    public static IHost? Host;

    public App()
    {
        InitializeComponent();
    }

    private IHost SetupHost(IConfiguration configuration)
    {
        var host = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                var apiSettings = new ApiSettings();
                configuration.GetSection(typeof(ApiSettings).Name).Bind(apiSettings);
                services.AddSingleton(apiSettings);

                services.AddCoreLayer();
                services.AddInfrastructureLayer(apiSettings);

                services.AddSingleton<INavigationService, WinUiNavigationService>();
                services.AddSingleton<IWindowManagerService, WinUiWindowManagerService>();
                services.AddTransient<IDialogService, WinUiDialogService>();
            })
            .Build();

        return host;
    }

    protected override void OnLaunched(LaunchActivatedEventArgs args)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables();

        var configuration = builder.Build();

        Host = SetupHost(configuration);

        var windowManagerService = Host.Services.GetRequiredService<IWindowManagerService>();
        var authService = Host.Services.GetRequiredService<IAuthService>();

        if (authService.IsAuthenticated)
        {
            var mainWindow = new MainWindowView();
            windowManagerService.SetCurrentWindow(mainWindow);
            windowManagerService.OpenMainWindow();
        }
        else
        {
            var authWindow = new AuthWindowView();
            windowManagerService.SetCurrentWindow(authWindow);
            windowManagerService.OpenAuthWindow();
        }
    }
}
