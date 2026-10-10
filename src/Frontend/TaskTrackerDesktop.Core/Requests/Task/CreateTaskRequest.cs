using System;
using TaskTrackerDesktop.Core.Enums;

namespace TaskTrackerDesktop.Core.Requests.Task;

public sealed record CreateTaskRequest(
    string Title,
    string Description,
    TaskState TaskState,
    DateTime? Deadline,
    Guid ProcessId,
    Guid CreatedById,
    Guid AssignedToId
);
