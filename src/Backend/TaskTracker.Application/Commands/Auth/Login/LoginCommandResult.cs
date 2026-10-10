namespace TaskTracker.Application.Commands.Auth.Login;

public sealed record LoginCommandResult(
    bool IsSucceed,
    string? AccessToken,
    string? RefreshToken,
    string? ErrorCode
);