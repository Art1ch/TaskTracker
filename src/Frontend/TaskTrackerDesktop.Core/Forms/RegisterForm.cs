using CommunityToolkit.Mvvm.ComponentModel;

namespace TaskTrackerDesktop.Core.Forms;

public sealed partial class RegisterForm : ObservableObject
{
    [ObservableProperty]
    private string _email;

    [ObservableProperty]
    private string _firstName;

    [ObservableProperty]
    private string _lastName;

    [ObservableProperty]
    private string _password;
}