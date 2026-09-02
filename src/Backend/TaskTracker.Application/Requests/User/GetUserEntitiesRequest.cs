using TaskTracker.Core.Enums;

namespace TaskTracker.Application.Requests.User;

public sealed record GetUserEntitiesRequest(
    int Page,
    int PageSize,
    DateTime? From,
    DateTime? To,
    UserRole? Role,
    string? FirstName,
    string? LastName
);
