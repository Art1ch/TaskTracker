using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;
using TaskTrackerDesktop.Core.Auth;
using TaskTrackerDesktop.Core.Interfaces;

namespace TaskTrackerDesktop.Core.ViewModels;

public sealed partial class RegisterPageViewModel : ViewModelBase
{
    private readonly IAuthService _authService;
    private readonly IDialogService _dialogService;

    [ObservableProperty]
    private RegisterForm _registerForm = new();

    public RegisterPageViewModel(
        IAuthService authService,
        IDialogService dialogService,
        INavigationService navigationService
    ) : base(navigationService)
    {
        _authService = authService;
        _dialogService = dialogService;
    }

    [RelayCommand]
    public async Task Register()
    {
        if (IsLoading) return;

        IsLoading = true;

        try
        {
            var response = await _authService.RegisterAsync(
                RegisterForm.Email,
                RegisterForm.FirstName,
                RegisterForm.LastName,
                RegisterForm.Password
            );

            if (response.IsSucceed)
            {
                _navigationService.NavigateToPage("LoginPage");
            }
            else
            {
                await _dialogService.ShowError(response.ErrorMessage!);
            }
        }
        catch
        {
            await _dialogService.ShowError("Unexpected error. Please try again or later");
        }
        finally
        {
            IsLoading = false;
        }
    }
}
