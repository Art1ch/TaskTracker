using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using TaskTrackerDesktop.Core.Models;

namespace TaskTrackerDesktop.WinUI.UserControls;

public sealed partial class TaskCardView : UserControl
{
    public static readonly DependencyProperty TaskModelProperty =
        DependencyProperty.Register(
            nameof(TaskModel),
            typeof(TaskModel),
            typeof(TaskCardView),
            new PropertyMetadata(null)
        );
    public TaskModel TaskModel
    {
        get => (TaskModel)GetValue(TaskModelProperty);
        set => SetValue(TaskModelProperty, value);
    }

    public TaskCardView()
    {
        InitializeComponent();
    }
}
