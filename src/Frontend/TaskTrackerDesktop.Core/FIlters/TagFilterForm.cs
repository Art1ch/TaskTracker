using CommunityToolkit.Mvvm.ComponentModel;
using System;

namespace TaskTrackerDesktop.Core.Filters;

public sealed partial class TagFilterForm : FilterFormBase
{
    [ObservableProperty]
    private Guid? _processId;

    [ObservableProperty]
    private string? _name;
}
