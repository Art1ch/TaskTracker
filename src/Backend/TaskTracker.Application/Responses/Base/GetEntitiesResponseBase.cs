namespace TaskTracker.Application.Responses.Base;

public abstract record GetEntitiesResponseBase(
    int Page,
    int PageSize,
    int TotalCount,
    int TotalPages,
    bool HasNextPage,
    bool HasPreviousPage
);
