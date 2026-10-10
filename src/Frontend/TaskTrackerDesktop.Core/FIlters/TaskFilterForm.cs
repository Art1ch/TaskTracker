using CommunityToolkit.Mvvm.ComponentModel;
using System;
using TaskTrackerDesktop.Core.Enums;

namespace TaskTrackerDesktop.Core.Filters;

public sealed partial class TaskFilterForm : FilterFormBase
{
    [ObservableProperty]
    private Guid? _processId;

    [ObservableProperty]
    private Guid? _createdById;

    [ObservableProperty]
    private Guid? _assignedToId;

    [ObservableProperty]
    private string? _title;

    [ObservableProperty]
    private string? _description;

    [ObservableProperty]
    private TaskState? _taskState;

    [ObservableProperty]
    private DateTime? _deadline;
}
