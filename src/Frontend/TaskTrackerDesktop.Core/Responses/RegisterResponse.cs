namespace TaskTrackerDesktop.Core.Responses;

public sealed record RegisterResponse(
    bool IsSucceed,
    string? ErrorMessage
);
