using TaskTracker.Application.Requests.Base;

namespace TaskTracker.Application.Requests.Process;

public sealed record GetProcessEntitiesRequest(
    int Page,
    int PageSize,
    DateTime? From,
    DateTime? To,
    string? Name,
    string? Description,
    bool? IsActive
) : GetEntitiesRequestBase(Page, PageSize, From, To);