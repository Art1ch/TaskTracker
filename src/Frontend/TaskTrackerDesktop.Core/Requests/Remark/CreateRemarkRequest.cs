using System;

namespace TaskTrackerDesktop.Core.Requests.Remark;

public sealed record CreateRemarkRequest(
    string Text,
    Guid TaskId,
    Guid UserId
);
