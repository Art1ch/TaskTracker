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

public sealed partial class TaskDetailPageViewModel : PaginationViewModelBase
{
    private readonly ITaskService _taskService;
    private readonly IRemarkService _remarkService;
    private readonly IDialogService _dialogService;
    private readonly IMapper _mapper;
    private RemarkFilterForm _remarkFilterForm => (RemarkFilterForm)Filter;

    [ObservableProperty]
    private TaskModel _taskModel;

    [ObservableProperty]
    private ObservableCollection<RemarkModel> _remarkModels;

    private Guid _taskId;

    public TaskDetailPageViewModel(
        ITaskService taskService,
        IRemarkService remarkService,
        IDialogService dialogService,
        IMapper mapper,
        INavigationService navigationService) : base(navigationService)
    {
        _taskService = taskService;
        _remarkService = remarkService;
        _dialogService = dialogService;
        _mapper = mapper;

        Filter = new RemarkFilterForm();
    }

    [RelayCommand]
    protected override async Task LoadPage()
    {
        if (IsLoading) return;

        IsLoading = true;

        try
        {
            var getTaskResponse = await _taskService.GetTaskAsync(_taskId);
            var taskModel = _mapper.Map<TaskModel>(getTaskResponse);

            TaskModel = taskModel;

            var getRemarksResponse = await _remarkService.GetRemarksAsync(_remarkFilterForm);
            var remarkModels = _mapper.Map<IEnumerable<RemarkModel>>(getRemarksResponse.Remarks);

            RemarkModels = new ObservableCollection<RemarkModel>(remarkModels);

            TotalPages = getRemarksResponse.TotalPages;
            TotalCount = getRemarksResponse.TotalCount;
            HasNextPage = getRemarksResponse.HasNextPage;
            HasPreviousPage = getRemarksResponse.HasPreviousPage;

            Filter.Page = getRemarksResponse.Page;
            Filter.PageSize = getRemarksResponse.PageSize;
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

    public void SetTaskId(Guid id)
    {
        _taskId = id;
    }
}
