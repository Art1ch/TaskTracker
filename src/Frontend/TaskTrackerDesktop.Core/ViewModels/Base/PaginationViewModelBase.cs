using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading;
using System.Threading.Tasks;
using TaskTrackerDesktop.Core.Filters;
using TaskTrackerDesktop.Core.Interfaces;

namespace TaskTrackerDesktop.Core.ViewModels.Base;

public abstract partial class PaginationViewModelBase : ViewModelBase
{
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(CanGoNext))]
    [NotifyPropertyChangedFor(nameof(CanGoPrevious))]
    private FilterFormBase _filter;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(CanGoNext))]
    private bool _hasNextPage;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(CanGoPrevious))] 
    private bool _hasPreviousPage;

    [ObservableProperty]
    private int _totalPages;

    [ObservableProperty]
    private int _totalCount;

    public bool CanGoNext => !IsLoading && HasNextPage;
    public bool CanGoPrevious => !IsLoading && HasPreviousPage;

    protected PaginationViewModelBase(INavigationService navigationService) : base(navigationService)
    {
    }

    protected abstract Task LoadPage();

    [RelayCommand]
    private Task GoToNextPage(CancellationToken ct)
    {
        if (CanGoNext)
        {
            Filter.Page++;
            return LoadPage();
        }

        return Task.CompletedTask;
    }

    [RelayCommand]
    private Task GoToPreviousPage(CancellationToken ct)
    {
        if (CanGoPrevious)
        {
            Filter.Page--;
            return LoadPage();
        }

        return Task.CompletedTask;
    }
}
