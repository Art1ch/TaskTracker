using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using TaskTrackerDesktop.Core.Models;

namespace TaskTrackerDesktop.WinUI.UserControls;

public sealed partial class RemarkCardView : UserControl
{
    public static readonly DependencyProperty RemarkModelProperty =
        DependencyProperty.Register(
            nameof(RemarkModel),
            typeof(RemarkModel),
            typeof(RemarkCardView),
            new PropertyMetadata(null)
        );
    public RemarkModel RemarkModel
    {
        get => (RemarkModel)GetValue(RemarkModelProperty);
        set => SetValue(RemarkModelProperty, value);
    }
    public RemarkCardView()
    {
        InitializeComponent();
    }
}
