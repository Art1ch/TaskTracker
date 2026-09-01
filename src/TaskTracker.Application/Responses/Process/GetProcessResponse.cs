namespace TaskTracker.Application.Responses.Process;

public sealed record GetProcessResponse(
    Guid Id,
    string Name,
    string Description,
    bool IsActive
);
