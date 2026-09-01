using TaskTracker.Core.Enums;

namespace TaskTracker.Application.Queries.Task.GetEntities;

public sealed record GetTaskEntitiesQueryResultItem(
    Guid Id,
    string Title,
    string Description,
    TaskState State,
    DateTime? Deadline,
    Guid ProcessId,
    Guid CreatedById
);