using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MapsterMapper;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using TaskTrackerDesktop.Core.Filters;
using TaskTrackerDesktop.Core.Interfaces;
using TaskTrackerDesktop.Core.Models;
using TaskTrackerDesktop.Core.ViewModels.Base;

namespace TaskTrackerDesktop.Core.ViewModels;

public sealed partial class UsersPageViewModel : PaginationViewModelBase
{
    private readonly IUserService _userService;
    private readonly IDialogService _dialogService;
    private readonly IMapper _mapper;

    private UserFilterForm _userFilterForm => (UserFilterForm)Filter;

    [ObservableProperty]
    private ObservableCollection<UserModel> _userModels = new();

    public UsersPageViewModel(
        INavigationService navigationService,
        IUserService userService,
        IDialogService dialogSerivce,
        IMapper mapper
    ) : base(navigationService)
    {
        _userService = userService;
        _dialogService = dialogSerivce;
        _mapper = mapper;

        Filter = new UserFilterForm();

        _ = LoadPage();
    }

    [RelayCommand]
    protected override async Task LoadPage()
    {
        if (IsLoading) return;

        IsLoading = true;

        try
        {
            var response = await _userService.GetUsersAsync(_userFilterForm);
            var userModels = _mapper.Map<IEnumerable<UserModel>>(response.Users);

            UserModels = new ObservableCollection<UserModel>(userModels);

            TotalPages = response.TotalPages;
            TotalCount = response.TotalCount;
            HasNextPage = response.HasNextPage;
            HasPreviousPage = response.HasPreviousPage;

            Filter.Page = response.Page;
            Filter.PageSize = response.PageSize;
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
