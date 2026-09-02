using TaskTracker.Core.Enums;

namespace TaskTracker.Application.Requests.Task;

public sealed record GetTaskEntitiesRequest(
    int Page,
    int PageSize,
    Guid? ProcessId,
    Guid? CreatedById,
    Guid? AssignedToId,
    DateTime? From,
    DateTime? To,
    string? Title,
    string? Description,
    TaskState? State,
    DateTime? Deadline
);
