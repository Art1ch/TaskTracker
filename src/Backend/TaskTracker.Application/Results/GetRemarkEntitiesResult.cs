using TaskTracker.Application.Results.Base;
using TaskTracker.Application.Results.Items;

namespace TaskTracker.Application.Results;

public sealed record GetRemarkEntitiesResult(
    IEnumerable<RemarkItem> Remarks,
    int Page,
    int PageSize,
    int TotalPages,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage
) : GetEntitiesResultBase(Page, PageSize, TotalPages, TotalCount, HasNextPage, HasPreviousPage);
