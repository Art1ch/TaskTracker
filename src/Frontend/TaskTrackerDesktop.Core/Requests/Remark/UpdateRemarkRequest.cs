using System;

namespace TaskTrackerDesktop.Core.Requests.Remark;

public sealed record UpdateRemarkRequest(
    Guid Id,
    string? Text,
    Guid? TaskId,
    Guid? UserId
);
