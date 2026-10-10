using System.Collections.Generic;
using TaskTrackerDesktop.Core.Responses.Base;

namespace TaskTrackerDesktop.Core.Responses.Process;

public sealed record GetProcessEntitiesResponse(
    IEnumerable<GetProcessEntitiesResponseItem> Processes,
    int Page,
    int PageSize,
    int TotalCount,
    int TotalPages,
    bool HasNextPage,
    bool HasPreviousPage
) : GetEntitiesResponseBase(Page, PageSize, TotalCount, TotalPages, HasNextPage, HasPreviousPage);
