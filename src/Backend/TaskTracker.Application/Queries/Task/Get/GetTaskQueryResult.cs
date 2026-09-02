using TaskTracker.Core.Enums;

namespace TaskTracker.Application.Queries.Task.Get;

public sealed record GetTaskQueryResult(
    Guid Id,
    string Title,
    string Description,
    TaskState Status,
    DateTime? Deadline,
    Guid ProcessId,
    Guid CreatedById
);