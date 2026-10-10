namespace TaskTracker.Application.Filters;

public sealed record ProcessFilter(
    int Page,
    int PageSize,
    DateTime? From,
    DateTime? To,
    string? Name,
    string? Description,
    bool? IsActive
) : FilterBase(Page, PageSize, From, To);
