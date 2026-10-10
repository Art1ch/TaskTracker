using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml.Controls;
using System;
using TaskTrackerDesktop.Core.Interfaces;
using TaskTrackerDesktop.Core.Models;
using TaskTrackerDesktop.Core.ViewModels;

namespace TaskTrackerDesktop.WinUI.Pages;

public sealed partial class TasksPageView : Page
{
    private readonly INavigationService _navigationService;
    public TasksPageViewModel ViewModel { get; }
    public TasksPageView()
    {
        _navigationService = App.Host!.Services.GetRequiredService<INavigationService>();
        ViewModel = App.Host!.Services.GetRequiredService<TasksPageViewModel>();

        InitializeComponent();
    }

    private void NavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
    {
        if (args.SelectedItemContainer?.Tag is string filterMode)
        {
            ViewModel.ChangeTaskFilterModeCommand.Execute(filterMode);
            ViewModel.LoadPageCommand.Execute(null);
        }
    }

    private void ListView_ItemClick(object sender, ItemClickEventArgs e)
    {
        if (e.ClickedItem is TaskModel clickedTask)
        {
            Guid taskId = clickedTask.Id;

            _navigationService.NavigateToPage("TaskDetail", taskId);
        }
    }
}
