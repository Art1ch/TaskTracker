namespace TaskTracker.Application.Requests.Remark;

public sealed record UpdateRemarkRequest(
    Guid Id,
    string? Text,
    Guid? TaskId,
    Guid? UserId
);
