namespace TaskTracker.Application.Queries.Tag.GetEntities;

public sealed record GetTagEntitiesQueryResult(
    IEnumerable<GetTagEntitiesQueryResultItem> Tags,
    int Page,
    int PageSize,
    int TotalCount,
    int TotalPages,
    bool HasNextPage,
    bool HasPreviousPage
);
