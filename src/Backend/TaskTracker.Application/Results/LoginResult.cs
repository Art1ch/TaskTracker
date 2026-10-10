using TaskTracker.Application.Results.Base;

namespace TaskTracker.Application.Results;

public sealed record LoginResult(
    bool IsSucceed,
    string? AccessToken,
    string? RefreshToken,
    string? ErrorCode
) : AuthResultBase(IsSucceed);