namespace TaskTrackerDesktop.Core.Requests.Auth;

public sealed record RefreshRequest(
    string RefreshToken
);