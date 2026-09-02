using CommunityToolkit.Mvvm.ComponentModel;

namespace TaskTrackerDesktop.Core.ViewModels;

public abstract partial class ViewModelBase : ObservableObject
{
    [ObservableProperty]
    private bool isLoading;
}