using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MapsterMapper;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TaskTrackerDesktop.Core.Enums;
using TaskTrackerDesktop.Core.Filters;
using TaskTrackerDesktop.Core.Interfaces;
using TaskTrackerDesktop.Core.Models;

namespace TaskTrackerDesktop.Core.ViewModels;

public sealed partial class DashboardPageViewModel : ViewModelBase
{
    private readonly ITaskService _taskService;
    private readonly IAuthService _authService;
    private readonly IDialogService _dialogService;
    private readonly IMapper _mapper;
    public bool CanExecuteCommand => !IsLoading;

    [ObservableProperty]
    private UserModel _currentUser;

    [ObservableProperty]
    private ObservableCollection<TaskModel> _recentTasksModels;

    public DashboardPageViewModel(
        INavigationService navigationService,
        ITaskService taskService,
        IAuthService authService,
        IDialogService dialogService,
        IMapper mapper
    ) : base(navigationService)
    {
        _taskService = taskService;
        _authService = authService;
        _dialogService = dialogService;
        _mapper = mapper;

        _currentUser = _authService.CurrentUser;

        _ = LoadRecentTasks();
    }

    [RelayCommand]
    private async Task LoadRecentTasks()
    { 
        IsLoading = true;
    
        var filter = new TaskFilterForm
        {
            Page = 1,
            PageSize = 10,
            AssignedToId = CurrentUser.Id,
            TaskState = TaskState.InProgress
        };

        try
        {
            var response = await _taskService.GetTasksAsync(filter);
            var recentTasksModels = _mapper.Map<IEnumerable<TaskModel>>(response.Tasks);

            RecentTasksModels = new ObservableCollection<TaskModel>(recentTasksModels);
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
