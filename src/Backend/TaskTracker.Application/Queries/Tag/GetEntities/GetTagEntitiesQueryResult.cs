namespace TaskTracker.Application.Queries.Tag.GetEntities;

public sealed record GetTagEntitiesQueryResult(
    IEnumerable<GetTagEntitiesQueryResultItem> Tags
);
