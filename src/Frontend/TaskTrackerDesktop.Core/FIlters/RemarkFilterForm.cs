using CommunityToolkit.Mvvm.ComponentModel;
using System;

namespace TaskTrackerDesktop.Core.Filters;

public sealed partial class RemarkFilterForm : FilterFormBase
{
    [ObservableProperty]
    private Guid? _taskId;

    [ObservableProperty]
    private string? _text;
}
