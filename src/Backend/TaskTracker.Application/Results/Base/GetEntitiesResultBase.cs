namespace TaskTracker.Application.Results.Base;

public abstract record GetEntitiesResultBase(
    int Page,
    int PageSize,
    int TotalPages,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage
);