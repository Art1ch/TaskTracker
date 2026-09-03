using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;
using TaskTrackerDesktop.Core.Interfaces;
using TaskTrackerDesktop.Core.Models;

namespace TaskTrackerDesktop.Core.ViewModels;

public sealed partial class MainShellViewModel : ViewModelBase
{
    private readonly IAuthService _authService;
    private readonly IDialogService _dialogService;

    [ObservableProperty]
    private UserModel currentUser;

    public MainShellViewModel(
        INavigationService navigationService,
        IAuthService authService,
        IDialogService dialogService
    ) : base(navigationService)
    {
        _authService = authService;
        _dialogService = dialogService;
    }

    [RelayCommand]
    public async Task Logout()
    {
        IsLoading = true;

        try
        {
            await _authService.LogoutAsync();
            _navigationService.NavigateTo("Login");
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
