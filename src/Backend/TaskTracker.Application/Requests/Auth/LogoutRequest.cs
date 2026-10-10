namespace TaskTracker.Application.Requests.Auth;

public sealed record LogoutRequest(
    string RefreshToken    
);