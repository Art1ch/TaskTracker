namespace TaskTracker.Application.Queries.Remark.GetEntities;

public sealed record GetRemarkEntitiesQueryResult(
    IEnumerable<GetRemarkEntitiesQueryResultItem> Remarks,
    int Page,
    int PageSize,
    int TotalCount,
    int TotalPages,
    bool HasNextPage,
    bool HasPreviousPage
);
