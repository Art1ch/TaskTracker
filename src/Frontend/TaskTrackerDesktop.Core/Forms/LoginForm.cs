using CommunityToolkit.Mvvm.ComponentModel;

namespace TaskTrackerDesktop.Core.Forms;

public sealed partial class LoginForm : ObservableObject
{
    [ObservableProperty]
    private string _email;

    [ObservableProperty]
    private string _password;
}
