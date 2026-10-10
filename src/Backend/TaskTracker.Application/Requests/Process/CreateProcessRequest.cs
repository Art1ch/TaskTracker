namespace TaskTracker.Application.Requests.Process;

public sealed record CreateProcessRequest(
    string Name,
    string Description,
    Guid AdminId,
    bool IsActive
);