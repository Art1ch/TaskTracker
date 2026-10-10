using System;
using TaskTrackerDesktop.Core.Requests.Base;

namespace TaskTrackerDesktop.Core.Requests.Tag;

public sealed record GetTagEntitiesRequest(
    int Page,
    int PageSize,
    Guid? ProcessId,
    DateTime? From,
    DateTime? To,
    string? Name
) : GetEntitiesRequestBase(Page, PageSize, From, To);