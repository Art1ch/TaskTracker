using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml.Controls;
using TaskTrackerDesktop.Core.ViewModels;

namespace TaskTrackerDesktop.WinUI.Pages;

public sealed partial class UsersPageView : Page
{
    public UsersPageViewModel ViewModel { get; }

    public UsersPageView()
    {
        ViewModel = App.Host!.Services.GetRequiredService<UsersPageViewModel>(); 
        InitializeComponent();
    }
}
