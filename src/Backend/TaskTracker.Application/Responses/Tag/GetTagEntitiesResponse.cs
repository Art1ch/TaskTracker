using TaskTracker.Application.Responses.Base;

namespace TaskTracker.Application.Responses.Tag;

public sealed record GetTagEntitiesResponse(
    IEnumerable<GetTagEntitiesResponseItem> Tags,
    int Page,
    int PageSize,
    int TotalCount,
    int TotalPages,
    bool HasNextPage,
    bool HasPreviousPage
) : GetEntitiesResponseBase(Page, PageSize, TotalCount, TotalPages, HasNextPage, HasPreviousPage);
