using TaskTracker.Core.Enums;

namespace TaskTracker.Application.Filters;

public sealed record TaskFilter(
    int Page,
    int PageSize,
    Guid? ProcessId,
    Guid? CreatedById,
    Guid? AssignedToId,
    DateTime? From,
    DateTime? To,
    string? Title,
    string? Description,
    TaskState? State,
    DateTime? Deadline
) : FilterBase(Page, PageSize, From, To);