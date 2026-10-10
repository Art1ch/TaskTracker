using TaskTracker.Core.Enums;

namespace TaskTracker.Application.Requests.Task;

public sealed record UpdateTaskQuery(
    Guid Id,
    string? Title,
    string? Description,
    TaskState? TaskState,
    DateTime? Deadline,
    Guid? AssignedToId
);
