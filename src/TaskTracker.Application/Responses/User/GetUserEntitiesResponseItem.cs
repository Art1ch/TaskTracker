using TaskTracker.Core.Enums;

namespace TaskTracker.Application.Responses.User;

public sealed record GetUserEntitiesResponseItem(
    Guid Id,
    string FirstName,
    string LastName,
    UserRole Role
);