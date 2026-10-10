using TaskTracker.Core.Enums;

namespace TaskTracker.Application.Results.Items;

public sealed record RemarkItem(
    Guid Id,
    string Text,
    string UsersFirstName,
    string UsersLastName,
    UserRole UserRole
);
