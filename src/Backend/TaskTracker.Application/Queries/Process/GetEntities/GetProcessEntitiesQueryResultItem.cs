namespace TaskTracker.Application.Queries.Process.GetEntities;

public sealed record GetProcessEntitiesQueryResultItem(
    Guid Id,
    string Name,
    string Description,
    bool IsActive
);