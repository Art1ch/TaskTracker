using System;

namespace TaskTrackerDesktop.Core.Responses.Remark;

public sealed record GetRemarkResponse(
    Guid Id,
    string Text,
    Guid UserId
);
