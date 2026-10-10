namespace TaskTracker.Application.Queries.User.GetEntities;

public sealed record GetUserEntitiesQueryResult(
    IEnumerable<GetUserEntitiesQueryResultItem> Users,
    int Page,
    int PageSize,
    int TotalCount,
    int TotalPages,
    bool HasNextPage,
    bool HasPreviousPage
);
