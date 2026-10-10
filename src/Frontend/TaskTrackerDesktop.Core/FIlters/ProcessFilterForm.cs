using CommunityToolkit.Mvvm.ComponentModel;
using System;

namespace TaskTrackerDesktop.Core.Filters;

public sealed partial class ProcessFilterForm : FilterFormBase
{
    [ObservableProperty]
    private string? _name;

    [ObservableProperty]
    private string? _description;

    [ObservableProperty]
    private bool? _isActive;
}
