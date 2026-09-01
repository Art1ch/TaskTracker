namespace TaskTracker.Application.Responses.Tag;

public sealed record GetTagEntitiesResponse(
    IEnumerable<GetTagEntitiesResponseItem> Tags
);
