using TaskTracker.Core.Enums;

namespace TaskTracker.Application.Queries.Remark.GetEntities;

public sealed record GetRemarkEntitiesQueryResultItem(
    Guid Id,
    string Text,
    string UsersFirstName,
    string UsersLastName,
    UserRole UserRole
);