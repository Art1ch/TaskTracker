using System.Collections.Generic;
using TaskTrackerDesktop.Core.Responses.Base;

namespace TaskTrackerDesktop.Core.Responses.Remark;

public sealed record GetRemarkEntitiesResponse(
    IEnumerable<GetRemarkEntitiesResponseItem> Remarks,
    int Page,
    int PageSize,
    int TotalCount,
    int TotalPages,
    bool HasNextPage,
    bool HasPreviousPage
) : GetEntitiesResponseBase(Page, PageSize, TotalCount, TotalPages, HasNextPage, HasPreviousPage);
