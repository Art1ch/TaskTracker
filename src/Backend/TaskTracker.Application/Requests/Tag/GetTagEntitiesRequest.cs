namespace TaskTracker.Application.Requests.Tag;

public sealed record GetTagEntitiesRequest(
    int Page,
    int PageSize,
    Guid? ProcessId,
    DateTime? From,
    DateTime? To,
    string? Name
);