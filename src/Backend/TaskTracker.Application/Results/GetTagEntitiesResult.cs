using TaskTracker.Application.Results.Base;
using TaskTracker.Core.Entities;

namespace TaskTracker.Application.Results;

public sealed record GetTagEntitiesResult(
    IEnumerable<TagEntity> Tags,
    int Page,
    int PageSize,
    int TotalPages,
    int TotalCount,
    bool HasNextPage,
    bool HasPreviousPage
) : GetEntitiesResultBase(Page, PageSize, TotalPages, TotalCount, HasNextPage, HasPreviousPage);