using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TaskTrackerDesktop.Core.Interfaces;

namespace TaskTrackerDesktop.Core.ViewModels;

public abstract partial class ViewModelBase : ObservableObject
{
    protected readonly INavigationService _navigationService;
    protected bool _canGoBack => _navigationService.CanGoBack;

    [ObservableProperty]
    private bool _isLoading;

    protected ViewModelBase(INavigationService navigationService)
    {
        _navigationService = navigationService;
    }

    [RelayCommand]
    public void GoBack()
    {
        if (_canGoBack)
        {
            _navigationService.GoBack();
        }
    }
}