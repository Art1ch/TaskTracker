using TaskTracker.Application.Requests.Base;
using TaskTracker.Core.Enums;

namespace TaskTracker.Application.Requests.User;

public sealed record GetUserEntitiesRequest(
    int Page,
    int PageSize,
    DateTime? From,
    DateTime? To,
    UserRole? UserRole,
    string? FirstName,
    string? LastName
) : GetEntitiesRequestBase(Page, PageSize, From, To);
