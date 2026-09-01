namespace TaskTracker.Application.Responses.Task;

public sealed record GetTaskEntitiesResponse(
    IEnumerable<GetTaskEntitiesResponseItem> Tasks
);
