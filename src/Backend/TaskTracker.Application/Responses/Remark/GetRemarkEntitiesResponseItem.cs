namespace TaskTracker.Application.Responses.Remark;

public sealed record GetRemarkEntitiesResponseItem(
    Guid Id,
    string Text,
    Guid UserId
);
