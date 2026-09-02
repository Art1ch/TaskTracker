namespace TaskTracker.Application.Requests.Remark;

public sealed record GetRemarkEntitiesRequest(
    int Page,
    int PageSize,
    Guid? TaskId,
    DateTime? From,
    DateTime? To,
    string? Text
);
