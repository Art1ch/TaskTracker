using TaskTracker.Core.Enums;

namespace TaskTracker.Application.Responses.Remark;

public sealed record GetRemarkEntitiesResponseItem(
    Guid Id,
    string Text,
    string UsersFirstName,
    string UsersLastName,
    UserRole UserRole
);
