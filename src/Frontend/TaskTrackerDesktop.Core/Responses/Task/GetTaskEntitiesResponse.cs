using System.Collections.Generic;
using TaskTrackerDesktop.Core.Responses.Base;

namespace TaskTrackerDesktop.Core.Responses.Task;

public sealed record GetTaskEntitiesResponse(
    IEnumerable<GetTaskEntitiesResponseItem> Tasks,
    int Page,
    int PageSize,
    int TotalCount,
    int TotalPages,
    bool HasNextPage,
    bool HasPreviousPage
) : GetEntitiesResponseBase(Page, PageSize, TotalCount, TotalPages, HasNextPage, HasPreviousPage);
