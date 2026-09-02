namespace TaskTracker.Application.Filters;

public sealed record TagFilter(
    int Page,
    int PageSize,
    Guid? ProcessId,
    DateTime? From,
    DateTime? To,
    string? Name
) : FilterBase(Page, PageSize, From, To);
