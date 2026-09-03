using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;
using TaskTrackerDesktop.Core.Forms;
using TaskTrackerDesktop.Core.Interfaces;

namespace TaskTrackerDesktop.Core.ViewModels;

public sealed partial class RegisterViewModel : ViewModelBase
{
    private readonly IAuthService _authService;
    private readonly IDialogService _dialogService;

    [ObservableProperty]
    private RegisterForm _registerForm;

    public RegisterViewModel(
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
                _navigationService.NavigateTo("Login");
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
