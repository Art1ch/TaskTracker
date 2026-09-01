namespace TaskTracker.Application.Responses.Tag;

public sealed record GetTagResponse(
    Guid Id,
    string Name
);
