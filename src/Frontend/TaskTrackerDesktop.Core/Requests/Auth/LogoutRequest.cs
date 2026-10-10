namespace TaskTrackerDesktop.Core.Requests.Auth;

public sealed record LogoutRequest(
    string RefreshToken    
);