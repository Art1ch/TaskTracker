using System;
using TaskTrackerDesktop.Core.Enums;

namespace TaskTrackerDesktop.Core.Responses.User;

public sealed record GetUserEntitiesResponseItem(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    UserRole UserRole
);