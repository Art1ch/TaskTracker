using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using TaskTrackerDesktop.Core.Models;

namespace TaskTrackerDesktop.WinUI.UserControls;

public sealed partial class ProcessCardView : UserControl
{
    public static readonly DependencyProperty ProcessModelProperty =
        DependencyProperty.Register(
            nameof(ProcessModel),
            typeof(ProcessModel),
            typeof(ProcessCardView),
            new PropertyMetadata(null)
        );
    public ProcessModel ProcessModel
    {
        get => (ProcessModel)GetValue(ProcessModelProperty);
        set => SetValue(ProcessModelProperty, value);
    }

    public ProcessCardView()
    {
        InitializeComponent();
    }
}
