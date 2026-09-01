namespace TaskTracker.Application.Filters;

public sealed record RemarkFilter(
    int Page,
    int PageSize,
    Guid? TaskId,
    DateTime? From,
    DateTime? To,
    string? Text
) : FilterBase(Page, PageSize, From, To);
