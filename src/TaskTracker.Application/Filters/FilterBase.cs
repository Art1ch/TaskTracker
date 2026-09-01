namespace TaskTracker.Application.Filters;

public abstract record FilterBase(
    int Page,
    int PageSize,
    DateTime? From,
    DateTime? To
);