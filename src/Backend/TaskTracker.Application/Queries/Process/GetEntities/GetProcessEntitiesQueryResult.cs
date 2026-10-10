namespace TaskTracker.Application.Queries.Process.GetEntities;

public sealed record GetProcessEntitiesQueryResult(
    IEnumerable<GetProcessEntitiesQueryResultItem> Processes,
    int Page,
    int PageSize,
    int TotalCount,
    int TotalPages,
    bool HasNextPage,
    bool HasPreviousPage
);
