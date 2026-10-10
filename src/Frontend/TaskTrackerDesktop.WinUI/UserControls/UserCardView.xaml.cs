using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using TaskTrackerDesktop.Core.Models;

namespace TaskTrackerDesktop.WinUI.UserControls;

public sealed partial class UserCardView : UserControl
{
    public static readonly DependencyProperty UserModelProperty =
        DependencyProperty.Register(
            nameof(UserModel),
            typeof(UserModel),
            typeof(UserCardView),
            new PropertyMetadata(null)
        );
    public UserModel UserModel
    {
        get => (UserModel)GetValue(UserModelProperty);
        set => SetValue(UserModelProperty, value);
    }
    public UserCardView()
    {
        InitializeComponent();
    }
}
