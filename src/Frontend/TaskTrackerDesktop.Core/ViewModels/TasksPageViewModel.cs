using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TaskTrackerDesktop.Core.Filters;
using TaskTrackerDesktop.Core.Interfaces;
using TaskTrackerDesktop.Core.Models;
using TaskTrackerDesktop.Core.ViewModels.Base;

namespace TaskTrackerDesktop.Core.ViewModels;

public sealed partial class TasksPageViewModel : PaginationViewModelBase
{
    private readonly ITaskService _taskService;
    private readonly IDialogService _dialogService;
    private readonly IMapper _mapper;
    private readonly Dictionary<string, Action<TaskFilterForm>> _filterStrategies;
    private TaskFilterForm _taskFilterForm => (TaskFilterForm)Filter;
    private string _currentFilterMode;

    [ObservableProperty]
    private ObservableCollection<TaskModel> _taskModels;


    public TasksPageViewModel(
        ITaskService taskService,
        IDialogService dialogService,
        IAuthService authService,
        IMapper mapper,
        INavigationService navigationService) : base(navigationService)
    {
        _taskService = taskService;
        _dialogService = dialogService;
        _mapper = mapper;

        Filter = new TaskFilterForm();

        _filterStrategies = new Dictionary<string, Action<TaskFilterForm>>()
        {
            { "AllTasks", taskFilterForm => taskFilterForm.AssignedToId = null},
            { "MyTasks", taskFilterForm => taskFilterForm.AssignedToId = authService.CurrentUser.Id}
        };
    }

    [RelayCommand]
    protected async override Task LoadPage()
    {
        if (IsLoading == true) return;

        IsLoading = true;

        TaskModels = new();

        if (_filterStrategies.TryGetValue(_currentFilterMode, out var applyFilter))
        {
            applyFilter(_taskFilterForm);
        }

        try
        {
            var response = await _taskService.GetTasksAsync(_taskFilterForm);
            var tasksModels = _mapper.Map<IEnumerable<TaskModel>>(response.Tasks);

            TaskModels = new ObservableCollection<TaskModel>(tasksModels);

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

    [RelayCommand]
    private async Task ChangeTaskFilterMode(string mode)
    {
        if (_currentFilterMode == mode) return;

        _currentFilterMode = mode;
        Filter.Page = 1;

        await LoadPage();
    }

}
