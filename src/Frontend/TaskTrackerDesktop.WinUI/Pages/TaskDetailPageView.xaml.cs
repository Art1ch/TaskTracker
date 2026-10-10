using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using System;
using TaskTrackerDesktop.Core.ViewModels;

namespace TaskTrackerDesktop.WinUI.Pages;

public sealed partial class TaskDetailPageView : Page
{
    public TaskDetailPageViewModel ViewModel { get; set; }

    public TaskDetailPageView()
    {
        ViewModel = App.Host!.Services.GetRequiredService<TaskDetailPageViewModel>();

        InitializeComponent();
    }

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        if (e.Parameter is Guid id)
        {
            ViewModel.SetTaskId(id);

            if (ViewModel.LoadPageCommand.CanExecute(null))
                ViewModel.LoadPageCommand.Execute(null);
        }

        base.OnNavigatedTo(e);
    }
}
