using System;
using TaskTrackerDesktop.Core.Enums;

namespace TaskTrackerDesktop.Core.Requests.Task;

public sealed record UpdateTaskQuery(
    Guid Id,
    string? Title,
    string? Description,
    TaskState? TaskState,
    DateTime? Deadline,
    Guid? AssignedToId
);
