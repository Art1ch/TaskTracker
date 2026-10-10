using System;

namespace TaskTrackerDesktop.Core.Requests.Process;

public sealed record UpdateProcessRequest(
    Guid Id,
    string? Name,
    string? Description,
    bool? IsActive
);