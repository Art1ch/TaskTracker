using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Mapster;
using System;
using System.Threading.Tasks;
using TaskTrackerDesktop.Core.Interfaces;
using TaskTrackerDesktop.Core.Models;

namespace TaskTrackerDesktop.Core.ViewModels;

public sealed partial class MainWindowViewModel : ViewModelBase
{
    private readonly IAuthService _authService;
    private readonly IDialogService _dialogService;
    private readonly IWindowManagerService _windowManagerService;

    [ObservableProperty]
    private UserModel _currentUser = new();

    public MainWindowViewModel(
        INavigationService navigationService,
        IAuthService authService,
        IDialogService dialogService,
        IWindowManagerService windowManagerService
    ) : base(navigationService)
    {
        _authService = authService;
        _dialogService = dialogService;
        _windowManagerService = windowManagerService;

        CurrentUser = _authService.CurrentUser;
    }

    [RelayCommand]
    private async Task Logout()
    {
        if (IsLoading) return;

        IsLoading = true;

        try
        {
            await _authService.LogoutAsync();
            _windowManagerService.OpenAuthWindow();
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
