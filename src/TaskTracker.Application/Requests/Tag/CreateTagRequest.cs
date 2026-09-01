namespace TaskTracker.Application.Requests.Tag;

public sealed record CreateTagRequest(
    Guid ProcessId,
    string Name
);
