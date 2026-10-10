using TaskTracker.Application.Responses.Base;

namespace TaskTracker.Application.Responses.Process;

public sealed record GetProcessEntitiesResponse(
    IEnumerable<GetProcessEntitiesResponseItem> Processes,
    int Page,
    int PageSize,
    int TotalCount,
    int TotalPages,
    bool HasNextPage,
    bool HasPreviousPage
) : GetEntitiesResponseBase(Page, PageSize, TotalCount, TotalPages, HasNextPage, HasPreviousPage);
