using CommunityToolkit.Mvvm.ComponentModel;
using System;
using TaskTrackerDesktop.Core.Enums;

namespace TaskTrackerDesktop.Core.Filters;

public sealed partial class TaskFilterForm : ObservableObject
{
    [ObservableProperty]
    private int _page = 1;

    [ObservableProperty]
    private int _pageSize = 25;

    [ObservableProperty]
    private DateTime? _from;

    [ObservableProperty]
    private DateTime? _to;

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
    private TaskState? _state;

    [ObservableProperty]
    private DateTime? _deadline;
}
