namespace TaskTracker.Application.Queries.Task.GetEntities;

public sealed record GetTaskEntitiesQueryResult(
    IEnumerable<GetTaskEntitiesQueryResultItem> Tasks,
    int Page,
    int PageSize,
    int TotalCount,
    int TotalPages,
    bool HasNextPage,
    bool HasPreviousPage
);
