namespace TaskTracker.Application.Queries.Task.GetEntities;

public sealed record GetTaskEntitiesQueryResult(
    IEnumerable<GetTaskEntitiesQueryResultItem> Tasks
);
