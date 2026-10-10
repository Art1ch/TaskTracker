namespace TaskTracker.Application.Requests.Auth;

public sealed record RefreshRequest(
    string RefreshToken
);