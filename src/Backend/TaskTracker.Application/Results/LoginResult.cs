using TaskTracker.Core.Enums;

namespace TaskTracker.Application.Results;

public sealed record LoginResult(
    bool IsSucceed,
    string? Token,
    string? ErrorCode,
    string? Email,
    UserRole? UserRole
);