namespace TaskTracker.Application.Results;

public sealed record RegisterResult(
    bool IsSucceed,
    string? ErrorCode
);