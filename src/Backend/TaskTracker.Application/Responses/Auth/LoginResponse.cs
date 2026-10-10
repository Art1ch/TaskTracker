namespace TaskTracker.Application.Responses.Auth;

public sealed record LoginResponse(
    bool IsSucceed,
    string? ErrorMessage,
    string? AccessToken,
    string? RefreshToken
);