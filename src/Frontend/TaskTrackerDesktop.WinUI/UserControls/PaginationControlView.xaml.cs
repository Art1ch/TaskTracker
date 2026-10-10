using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using TaskTrackerDesktop.Core.Filters;
using TaskTrackerDesktop.Core.Models;
using TaskTrackerDesktop.Core.ViewModels.Base;

namespace TaskTrackerDesktop.WinUI.UserControls;

public sealed partial class PaginationControlView : UserControl
{
    public static readonly DependencyProperty FilterFormProperty =
        DependencyProperty.Register(
            nameof(FilterForm),
            typeof(FilterFormBase),
            typeof(PaginationControlView),
            new PropertyMetadata(null)
        );
    public FilterFormBase FilterForm
    {
        get => (FilterFormBase)GetValue(FilterFormProperty);
        set => SetValue(FilterFormProperty, value);
    }

    public static readonly DependencyProperty PaginationViewModelProperty =
        DependencyProperty.Register(
            nameof(PaginationViewModel),
            typeof(PaginationViewModelBase),
            typeof(PaginationControlView),
            new PropertyMetadata(null)
        );
    public PaginationViewModelBase PaginationViewModel
    {
        get => (PaginationViewModelBase)GetValue(PaginationViewModelProperty);
        set => SetValue(PaginationViewModelProperty, value);
    }

    public PaginationControlView()
    {
        InitializeComponent();
    }
}
