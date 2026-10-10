using System;

namespace TaskTrackerDesktop.Core.Responses.Process;

public sealed record GetProcessEntitiesResponseItem(
    Guid Id,
    string Name,
    string Description,
    bool IsActive
);