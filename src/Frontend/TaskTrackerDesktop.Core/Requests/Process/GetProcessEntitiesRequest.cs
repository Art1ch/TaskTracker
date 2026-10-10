using System;
using TaskTrackerDesktop.Core.Requests.Base;

namespace TaskTrackerDesktop.Core.Requests.Process;

public sealed record GetProcessEntitiesRequest(
    int Page,
    int PageSize,
    DateTime? From,
    DateTime? To,
    string? Name,
    string? Description,
    bool? IsActive
) : GetEntitiesRequestBase(Page, PageSize, From, To);