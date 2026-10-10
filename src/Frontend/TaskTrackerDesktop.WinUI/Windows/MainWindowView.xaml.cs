using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using TaskTrackerDesktop.Core.Interfaces;
using TaskTrackerDesktop.Core.ViewModels;

namespace TaskTrackerDesktop.WinUI.Windows;

public sealed partial class MainWindowView : Window
{
    public MainWindowViewModel ViewModel { get; }

    private readonly INavigationService _navigationService;
    private readonly IWindowManagerService _windowManagerService;

    public MainWindowView()
    {
        ViewModel = App.Host!.Services.GetRequiredService<MainWindowViewModel>();

        _navigationService = App.Host!.Services.GetRequiredService<INavigationService>();
        _windowManagerService = App.Host!.Services.GetRequiredService<IWindowManagerService>();

        InitializeComponent();

        _windowManagerService.SetCurrentWindow(this);
        _windowManagerService.SetCurrentRoot(ContentFrame);

        _navigationService.InitializeFrame(ContentFrame);
        _navigationService.NavigateToPage("DashboardPage");

    }

    private void NavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
    {
        if (args.SelectedItemContainer?.Tag is string tag)
        {
            _navigationService.NavigateToPage(tag);
        }
    }
}
