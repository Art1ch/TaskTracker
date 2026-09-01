namespace TaskTracker.Application.Queries.Tag.Get;

public sealed record GetTagQueryResult(
    Guid Id,
    string Name
);