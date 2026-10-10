using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml.Controls;
using TaskTrackerDesktop.Core.ViewModels;

namespace TaskTrackerDesktop.WinUI.Pages;

public sealed partial class ProcessesPageView : Page
{
    public ProcessesPageViewModel ViewModel { get; }

    public ProcessesPageView()
    {
        ViewModel = App.Host!.Services.GetRequiredService<ProcessesPageViewModel>();
        InitializeComponent();
    }
}
