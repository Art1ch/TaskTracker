namespace TaskTracker.Application.Responses.Tag;

public sealed record GetTagEntitiesResponseItem(
    Guid Id,
    string Name
);