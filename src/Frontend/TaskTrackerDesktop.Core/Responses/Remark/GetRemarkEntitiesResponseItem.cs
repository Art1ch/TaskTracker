using System;
using TaskTrackerDesktop.Core.Enums;

namespace TaskTrackerDesktop.Core.Responses.Remark;

public sealed record GetRemarkEntitiesResponseItem(
    Guid Id,
    string Text,
    string UsersFirstName,
    string UsersLastName,
    UserRole UserRole
);
