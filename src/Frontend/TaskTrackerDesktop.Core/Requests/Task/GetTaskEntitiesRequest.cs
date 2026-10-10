using System;
using TaskTrackerDesktop.Core.Enums;
using TaskTrackerDesktop.Core.Requests.Base;

namespace TaskTrackerDesktop.Core.Requests.Task;

public sealed record GetTaskEntitiesRequest(
    int Page,
    int PageSize,
    Guid? ProcessId,
    Guid? CreatedById,
    Guid? AssignedToId,
    DateTime? From,
    DateTime? To,
    string? Title,
    string? Description,
    TaskState? TaskState,
    DateTime? Deadline
) : GetEntitiesRequestBase(Page, PageSize, From, To);
