using CommunityToolkit.Mvvm.ComponentModel;
using System;
using TaskTrackerDesktop.Core.Enums;

namespace TaskTrackerDesktop.Core.Filters;

public sealed partial class UserFilterForm : FilterFormBase
{
    [ObservableProperty]
    private UserRole? _userRole;

    [ObservableProperty]
    private string? _firstName;

    [ObservableProperty]
    private string? _lastName;
}
