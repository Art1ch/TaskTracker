using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TaskTrackerDesktop.Core.Filters;
using TaskTrackerDesktop.Core.Interfaces;
using TaskTrackerDesktop.Core.Models;

namespace TaskTrackerDesktop.Core.ViewModels;

public sealed partial class ProcessesPageViewModel : ViewModelBase
{
    private readonly IProcessService _processService;
    private readonly IDialogService _dialogService;

    [ObservableProperty]
    private ProcessFilterForm _processFilterForm;

    [ObservableProperty]
    private ObservableCollection<ProcessModel> _processModels;

    public ProcessesPageViewModel(
        INavigationService navigationService,
        IProcessService processService,
        IDialogService dialogService
    ) : base(navigationService)
    {
        _processService = processService;
        _dialogService = dialogService;

        ProcessFilterForm = new();
        ProcessModels = new();
    }

    [RelayCommand]
    public async Task LoadProcesses()
    {
        IsLoading = true;

        try
        {
            var processes = await _processService.GetProcessesAsync(ProcessFilterForm);
            ProcessModels = new ObservableCollection<ProcessModel>(processes);
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
