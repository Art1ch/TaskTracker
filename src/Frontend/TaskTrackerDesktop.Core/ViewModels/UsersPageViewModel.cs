using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TaskTrackerDesktop.Core.Filters;
using TaskTrackerDesktop.Core.Interfaces;
using TaskTrackerDesktop.Core.Models;

namespace TaskTrackerDesktop.Core.ViewModels;

public sealed partial class UsersPageViewModel : ViewModelBase
{
    private readonly IUserService _userService;
    private readonly IDialogService _dialogSerivce;

    [ObservableProperty]
    private UserFilterForm _userFilterForm;

    [ObservableProperty]
    private ObservableCollection<UserModel> _userModels;

    public UsersPageViewModel(
        INavigationService navigationService,
        IUserService userService,
        IDialogService dialogSerivce
    ) : base(navigationService)
    {
        _userService = userService;
        _dialogSerivce = dialogSerivce;

        UserFilterForm = new();
        UserModels = new();
    }

    [RelayCommand]
    public async Task LoadUsers()
    {
        IsLoading = true;

        try
        {
            var users = await _userService.GetUsersAsync(UserFilterForm);
            UserModels = new ObservableCollection<UserModel>(users);
        }
        catch
        {
            _dialogSerivce.ShowError("Unexpected error");
        }
        finally
        {
            IsLoading = false;
        }
    }
}
