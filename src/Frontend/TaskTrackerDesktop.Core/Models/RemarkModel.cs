using CommunityToolkit.Mvvm.ComponentModel;
using TaskTrackerDesktop.Core.Enums;

namespace TaskTrackerDesktop.Core.Models;

public sealed partial class RemarkModel : ModelBase
{
    [ObservableProperty]
    private string _text;

    [ObservableProperty]
    private string _usersFirstName;

    [ObservableProperty]
    private string _usersLastName;

    [ObservableProperty]
    private UserRole _usersRole;
}