namespace TaskTracker.Application.Queries.Process.GetEntities;

public sealed record GetProcessEntitiesQueryResult(
    IEnumerable<GetProcessEntitiesQueryResultItem> Processes
);
