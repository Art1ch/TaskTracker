using System.Collections.Generic;
using TaskTrackerDesktop.Core.Responses.Base;

namespace TaskTrackerDesktop.Core.Responses.User;

public sealed record GetUserEntitiesResponse(
    IEnumerable<GetUserEntitiesResponseItem> Users,
    int Page,
    int PageSize,
    int TotalCount,
    int TotalPages,
    bool HasNextPage,
    bool HasPreviousPage
) : GetEntitiesResponseBase(Page, PageSize, TotalCount, TotalPages, HasNextPage, HasPreviousPage);
