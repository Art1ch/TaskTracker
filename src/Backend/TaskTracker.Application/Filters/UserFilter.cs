using TaskTracker.Core.Enums;

namespace TaskTracker.Application.Filters;

public sealed record UserFilter(
    int Page,
    int PageSize,
    DateTime? From,
    DateTime? To,
    UserRole? UserRole,
    string? FirstName,
    string? LastName
) : FilterBase(Page, PageSize, From, To);
