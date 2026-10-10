namespace TaskTracker.Application.Queries.User.GetEntities;

public sealed record GetUserEntitiesQueryResultItem(
    Guid Id,
    string FirstName,
    string LastName
);