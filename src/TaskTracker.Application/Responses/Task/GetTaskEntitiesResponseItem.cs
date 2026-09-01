using TaskTracker.Core.Enums;

namespace TaskTracker.Application.Responses.Task;

public sealed record GetTaskEntitiesResponseItem(
    Guid Id,
    string Title,
    string Description,
    TaskState State,
    DateTime? Deadline,
    Guid ProcessId,
    Guid CreatedById
);