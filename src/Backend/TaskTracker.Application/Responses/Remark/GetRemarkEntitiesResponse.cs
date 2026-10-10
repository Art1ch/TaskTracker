using TaskTracker.Application.Responses.Base;

namespace TaskTracker.Application.Responses.Remark;

public sealed record GetRemarkEntitiesResponse(
    IEnumerable<GetRemarkEntitiesResponseItem> Remarks,
    int Page,
    int PageSize,
    int TotalCount,
    int TotalPages,
    bool HasNextPage,
    bool HasPreviousPage
) : GetEntitiesResponseBase(Page, PageSize, TotalCount, TotalPages, HasNextPage, HasPreviousPage);
