using TaskTrackerDesktop.Core.Enums;

namespace TaskTrackerDesktop.Core.Responses;

public sealed record LoginResponse(
    bool IsSucceed,
    string? ErrorMessage,
    string? Token,
    string? Email,
    UserRole? UserRole
);