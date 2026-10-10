using System;

namespace TaskTrackerDesktop.Core.Requests.Process;

public sealed record CreateProcessRequest(
    string Name,
    string Description,
    Guid AdminId,
    bool IsActive
);