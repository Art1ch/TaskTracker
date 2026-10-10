namespace TaskTrackerDesktop.Core.Responses.Auth;

public sealed record RefreshResponse(
    bool IsSucceed,
    string? ErrorMessage,
    string? AccessToken,
    string? RefreshToken
);