using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using TaskTrackerDesktop.Core.Interfaces;

namespace TaskTrackerDesktop.WinUI.Windows;

public sealed partial class AuthWindowView : Window
{
    private readonly INavigationService _navigationService;
    private readonly IWindowManagerService _windowManagerService;

    public AuthWindowView()
    {
        _navigationService = App.Host!.Services.GetRequiredService<INavigationService>();
        _windowManagerService = App.Host!.Services.GetRequiredService<IWindowManagerService>();

        InitializeComponent();

        _windowManagerService.SetCurrentWindow(this);
        _windowManagerService.SetCurrentRoot(ContentFrame);

        _navigationService.InitializeFrame(ContentFrame);
        _navigationService.NavigateToPage("LoginPage");

    }
}
