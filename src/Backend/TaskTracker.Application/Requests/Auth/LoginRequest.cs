namespace TaskTracker.Application.Requests.Auth;

public sealed record LoginRequest(
    string Email,
    string Password
);
