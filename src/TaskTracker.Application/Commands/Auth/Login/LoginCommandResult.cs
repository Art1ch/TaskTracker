namespace TaskTracker.Application.Commands.Auth.Login;

public sealed record LoginCommandResult(
    bool IsSucceed,
    string? Token,
    string? ErrorCode
);