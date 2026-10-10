using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml.Controls;
using TaskTrackerDesktop.Core.Interfaces;
using TaskTrackerDesktop.Core.ViewModels;

namespace TaskTrackerDesktop.WinUI.Pages;

public sealed partial class RegisterPageView : Page
{
    private readonly INavigationService _navigationService;
    public RegisterPageViewModel ViewModel { get; set; }
    public RegisterPageView()
    {
        _navigationService = App.Host!.Services.GetRequiredService<INavigationService>();
        ViewModel = App.Host!.Services.GetRequiredService<RegisterPageViewModel>();

        InitializeComponent();
    }
    private void PasswordBox_PasswordChanged(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        if (sender is PasswordBox passwordBox)
            ViewModel.RegisterForm.Password = passwordBox.Password;
    }

    private void HyperlinkButton_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        _navigationService.NavigateToPage("LoginPage");
    }
}
