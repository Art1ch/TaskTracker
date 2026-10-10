namespace TaskTracker.Application.Requests.Process;

public sealed record UpdateProcessRequest(
    Guid Id,
    string? Name,
    string? Description,
    bool? IsActive
);