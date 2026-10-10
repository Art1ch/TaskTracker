using CommunityToolkit.Mvvm.ComponentModel;
using System;
using TaskTrackerDesktop.Core.Enums;

namespace TaskTrackerDesktop.Core.Models;

public sealed partial class UserModel : ModelBase
{
    [ObservableProperty]
    private string _firstName;

    [ObservableProperty]
    private string _lastName;

    [ObservableProperty]
    private UserRole _userRole;
}