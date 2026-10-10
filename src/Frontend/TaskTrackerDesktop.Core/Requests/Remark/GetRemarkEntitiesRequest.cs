using System;
using TaskTrackerDesktop.Core.Requests.Base;

namespace TaskTrackerDesktop.Core.Requests.Remark;

public sealed record GetRemarkEntitiesRequest(
    int Page,
    int PageSize,
    Guid? TaskId,
    DateTime? From,
    DateTime? To,
    string? Text
) : GetEntitiesRequestBase(Page, PageSize, From, To);
