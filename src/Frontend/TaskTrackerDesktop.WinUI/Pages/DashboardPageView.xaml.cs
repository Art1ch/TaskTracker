using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml.Controls;
using TaskTrackerDesktop.Core.ViewModels;

namespace TaskTrackerDesktop.WinUI.Pages;

public sealed partial class DashboardPageView : Page
{
    public DashboardPageViewModel ViewModel { get; }

    public DashboardPageView()
    {
        ViewModel = App.Host!.Services.GetRequiredService<DashboardPageViewModel>();
        InitializeComponent();
    }
}
