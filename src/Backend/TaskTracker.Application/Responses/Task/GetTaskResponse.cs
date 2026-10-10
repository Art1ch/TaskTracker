using TaskTracker.Core.Enums;

namespace TaskTracker.Application.Responses.Task;

public sealed record GetTaskResponse(
    Guid Id,
    string Title,
    string Description,
    TaskState TaskState,
    DateTime? Deadline,
    Guid ProcessId,
    Guid CreatedById
);
