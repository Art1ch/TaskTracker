using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;
using TaskTrackerDesktop.Core.Auth;
using TaskTrackerDesktop.Core.Interfaces;

namespace TaskTrackerDesktop.Core.ViewModels;

public sealed partial class LoginPageViewModel : ViewModelBase
{
    private readonly IAuthService _authService;
    private readonly IWindowManagerService _windowManagerService;
    private readonly IDialogService _dialogService;

    [ObservableProperty]
    private LoginForm _loginForm = new();

    public LoginPageViewModel(
        INavigationService navigationService,
        IAuthService authService,
        IDialogService dialogService,
        IWindowManagerService windowManagerService
    ) : base(navigationService)
    {
        _authService = authService;
        _dialogService = dialogService;
        _windowManagerService = windowManagerService;
    }

    [RelayCommand]
    private async Task Login()
    {
        if (IsLoading) return;

        IsLoading = true;

        try
        {
            var response = await _authService.LoginAsync(LoginForm.Email, LoginForm.Password);

            if (response.IsSucceed)
            {
                _windowManagerService.OpenMainWindow();
            }
            else
            {
                await _dialogService.ShowError(response.ErrorMessage!);
            }
        }
        catch
        {
            await _dialogService.ShowError("Unexpected error");
        }
        finally
        {
            IsLoading = false;
        }
    }

    [RelayCommand]
    public void GoToRegistration()
    {
        _navigationService.NavigateToPage("RegisterPage");
    }
}
