namespace TaskTracker.Application.Requests.Remark;

public sealed record CreateRemarkRequest(
    string Text,
    Guid TaskId,
    Guid UserId
);
