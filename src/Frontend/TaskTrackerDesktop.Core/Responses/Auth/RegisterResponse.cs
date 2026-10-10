namespace TaskTrackerDesktop.Core.Responses.Auth;

public sealed record RegisterResponse(
    bool IsSucceed,
    string? ErrorMessage
);
