using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;
using TaskTrackerDesktop.Core.Forms;
using TaskTrackerDesktop.Core.Interfaces;

namespace TaskTrackerDesktop.Core.ViewModels;

public sealed partial class LoginViewModel : ViewModelBase
{
    private readonly IAuthService _authService; 
    private readonly INavigationService _navigationService;
    private readonly IDialogService _dialogService;

    [ObservableProperty]
    private LoginForm loginForm;

    public LoginViewModel(
        INavigationService navigationService,
        IAuthService authService,
        IDialogService dialogService
    )
    {
        _navigationService = navigationService;
        _authService = authService;
        _dialogService = dialogService;
    }

    [RelayCommand]
    public async Task Login()
    {
        IsLoading = true;

        try
        {
            var response = await _authService.LoginAsync(LoginForm.Email, LoginForm.Password);

            if (response.IsSucceed)
            {
                _navigationService.NavigateToMainShell();
            }
            else
            {
                _dialogService.ShowError(response.ErrorMessage!);
            }
        }
        catch
        {
            _dialogService.ShowError("Unexpected error");
        }
        finally
        {
            IsLoading = false;
        }
    }
}
