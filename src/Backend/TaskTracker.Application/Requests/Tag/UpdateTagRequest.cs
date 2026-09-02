namespace TaskTracker.Application.Requests.Tag;

public sealed record UpdateTagRequest(
    Guid Id,
    string Name
);
