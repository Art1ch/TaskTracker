namespace TaskTracker.Application.Responses.Remark;

public sealed record GetRemarkResponse(
    Guid Id,
    string Text,
    Guid UserId
);
