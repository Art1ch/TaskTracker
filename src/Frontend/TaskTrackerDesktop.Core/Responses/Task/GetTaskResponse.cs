using System;
using TaskTrackerDesktop.Core.Enums;

namespace TaskTrackerDesktop.Core.Responses.Task;

public sealed record GetTaskResponse(
    Guid Id,
    string Title,
    string Description,
    TaskState TaskState,
    DateTime? Deadline,
    Guid ProcessId,
    Guid CreatedById
);
