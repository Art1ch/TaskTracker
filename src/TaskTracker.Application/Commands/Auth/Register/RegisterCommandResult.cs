namespace TaskTracker.Application.Commands.Auth.Register;

public sealed record RegisterCommandResult(
    bool IsSucceed,
    string? ErrorCode
);