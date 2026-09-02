namespace TaskTracker.Application.Queries.User.GetEntities;

public sealed record GetUserEntitiesQueryResult(
    IEnumerable<GetUserEntitiesQueryResultItem> Users
);
