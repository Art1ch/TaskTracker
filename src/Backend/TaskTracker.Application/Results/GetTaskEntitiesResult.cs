using TaskTracker.Application.Results.Base;
using TaskTracker.Core.Entities;

namespace TaskTracker.Application.Results;

public sealed record GetTaskEntitiesResult(
    IEnumerable<TaskEntity> Tasks,
    int Page,
    int PageSize,
    int TotalPages,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage
) : GetEntitiesResultBase(Page, PageSize, TotalPages, TotalCount, HasNextPage, HasPreviousPage);
