namespace TaskTracker.Application.Requests.Process;

public sealed record AddUserToProcessRequest(
    Guid UserId,
    Guid ProcessId
);
