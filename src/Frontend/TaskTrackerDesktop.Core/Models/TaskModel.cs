using CommunityToolkit.Mvvm.ComponentModel;
using System;
using TaskTrackerDesktop.Core.Enums;

namespace TaskTrackerDesktop.Core.Models;

public sealed partial class TaskModel : ModelBase
{
    [ObservableProperty]
    private string _title;

    [ObservableProperty]
    private string _description;

    [ObservableProperty]
    private TaskState _taskState;

    [ObservableProperty]
    private DateTime? _deadline;

    [ObservableProperty]
    private Guid _processId;

    [ObservableProperty]
    private Guid _createdById;
}
