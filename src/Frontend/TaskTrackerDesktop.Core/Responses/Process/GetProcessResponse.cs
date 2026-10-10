using System;

namespace TaskTrackerDesktop.Core.Responses.Process;

public sealed record GetProcessResponse(
    Guid Id,
    string Name,
    string Description,
    bool IsActive
);
