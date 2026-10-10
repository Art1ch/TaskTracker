namespace TaskTrackerDesktop.Core.Requests.Auth;

public sealed record LoginRequest(
    string Email,
    string Password
);
