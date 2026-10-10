using TaskTracker.Application.Results.Base;

namespace TaskTracker.Application.Results;

public sealed record RefreshResult(
    bool IsSucceed,
    string? ErrorCode,
    string? AccessToken,
    string? RefreshToken
) : AuthResultBase(IsSucceed);