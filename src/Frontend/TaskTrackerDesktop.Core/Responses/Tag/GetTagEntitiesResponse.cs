using System.Collections.Generic;
using TaskTrackerDesktop.Core.Responses.Base;

namespace TaskTrackerDesktop.Core.Responses.Tag;

public sealed record GetTagEntitiesResponse(
    IEnumerable<GetTagEntitiesResponseItem> Tags,
    int Page,
    int PageSize,
    int TotalCount,
    int TotalPages,
    bool HasNextPage,
    bool HasPreviousPage
) : GetEntitiesResponseBase(Page, PageSize, TotalCount, TotalPages, HasNextPage, HasPreviousPage);
