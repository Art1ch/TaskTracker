namespace TaskTracker.Application.Responses.Auth;

public sealed record AuthResponse(
    bool IsSucceed,
    string? ErrorMessage
);