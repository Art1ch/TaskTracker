using TaskTracker.Core.Enums;

namespace TaskTracker.Application.Queries.User.Get;

public sealed record GetUserQueryResult(
    Guid Id,
    string FirstName,
    string LastName,
    UserRole Role
);