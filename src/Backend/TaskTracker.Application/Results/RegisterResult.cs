using TaskTracker.Application.Results.Base;

namespace TaskTracker.Application.Results;

public sealed record RegisterResult(
    bool IsSucceed,
    string? ErrorCode
) : AuthResultBase(IsSucceed);