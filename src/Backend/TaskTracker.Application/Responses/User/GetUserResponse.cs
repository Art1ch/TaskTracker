using TaskTracker.Core.Enums;

namespace TaskTracker.Application.Responses.User;

public sealed record GetUserResponse(
    Guid Id,
    string FirstName,
    string LastName,
    UserRole Role,
    string Email
);
