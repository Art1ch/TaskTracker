namespace TaskTracker.Application.Queries.Process.Get;

public sealed record GetProcessQueryResult(
    Guid Id,
    string Name,
    string Description,
    bool IsActive
);