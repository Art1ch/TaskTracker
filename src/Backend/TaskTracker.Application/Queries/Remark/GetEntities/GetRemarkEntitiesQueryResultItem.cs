namespace TaskTracker.Application.Queries.Remark.GetEntities;

public sealed record GetRemarkEntitiesQueryResultItem(
    Guid Id,
    string Text,
    Guid UserId
);