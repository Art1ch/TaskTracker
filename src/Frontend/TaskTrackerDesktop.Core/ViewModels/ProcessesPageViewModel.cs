using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MapsterMapper;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TaskTrackerDesktop.Core.Filters;
using TaskTrackerDesktop.Core.Interfaces;
using TaskTrackerDesktop.Core.Models;
using TaskTrackerDesktop.Core.ViewModels.Base;

namespace TaskTrackerDesktop.Core.ViewModels;

public sealed partial class ProcessesPageViewModel : PaginationViewModelBase
{
    private readonly IProcessService _processService;
    private readonly IDialogService _dialogService;
    private readonly IMapper _mapper;

    private ProcessFilterForm _processFilterForm => (ProcessFilterForm)Filter;

    [ObservableProperty]
    private ObservableCollection<ProcessModel> _processModels;

    public ProcessesPageViewModel(
        INavigationService navigationService,
        IProcessService processService,
        IDialogService dialogService,
        IMapper mapper
    ) : base(navigationService)
    {
        _processService = processService;
        _dialogService = dialogService;
        _mapper = mapper;

        Filter = new ProcessFilterForm();

        _ = LoadPage();
    }

    [RelayCommand]
    protected async override Task LoadPage()
    {
        if (IsLoading) return;
        
        IsLoading = true;

        try
        {
            var response = await _processService.GetProcessesAsync(_processFilterForm);
            var processModels = _mapper.Map<IEnumerable<ProcessModel>>(response.Processes);

            ProcessModels = new ObservableCollection<ProcessModel>(processModels);

            TotalPages = response.TotalPages;
            TotalCount = response.TotalCount;
            HasNextPage = response.HasNextPage;
            HasPreviousPage = response.HasPreviousPage;

            Filter.Page = response.Page;
            Filter.PageSize = response.PageSize;
        }
        catch
        {
            await _dialogService.ShowError("Unexpected error");
        }
        finally
        {
            IsLoading = false;
        }
    }
}
