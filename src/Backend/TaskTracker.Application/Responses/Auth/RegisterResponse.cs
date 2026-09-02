namespace TaskTracker.Application.Responses.Auth;

public sealed record RegisterResponse(
    bool IsSucceed,
    string? ErrorMessage
);
