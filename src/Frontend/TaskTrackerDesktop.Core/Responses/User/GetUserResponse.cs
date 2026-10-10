using System;
using TaskTrackerDesktop.Core.Enums;

namespace TaskTrackerDesktop.Core.Responses.User;

public sealed record GetUserResponse(
    Guid Id,
    string FirstName,
    string LastName,
    UserRole UserRole,
    string Email
);
