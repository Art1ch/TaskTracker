namespace TaskTracker.Application.Commands.Auth.Refresh;

public sealed record RefreshCommandResult(
    bool IsSucceed,
    string? ErrorCode,
    string? AccessToken,
    string? RefreshToken
);