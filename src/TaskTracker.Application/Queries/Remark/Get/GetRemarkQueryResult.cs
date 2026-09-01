namespace TaskTracker.Application.Queries.Remark.Get;

public sealed record GetRemarkQueryResult(
    Guid Id,
    string Text,
    Guid UserId
);