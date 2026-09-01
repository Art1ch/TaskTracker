using TaskTracker.Core.Enums;

namespace TaskTracker.Application.Requests.Task;

public sealed record CreateTaskRequest(
    string Title,
    string Description,
    TaskState State,
    DateTime? Deadline,
    Guid ProcessId,
    Guid CreatedById,
    Guid AssignedToId
);
