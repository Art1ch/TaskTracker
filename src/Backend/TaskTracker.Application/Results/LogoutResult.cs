using TaskTracker.Application.Results.Base;

namespace TaskTracker.Application.Results;

public sealed record LogoutResult(
    bool IsSucceed
) : AuthResultBase(IsSucceed);