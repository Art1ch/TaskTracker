using System;

namespace TaskTrackerDesktop.Core.Requests.Tag;

public sealed record CreateTagRequest(
    Guid ProcessId,
    string Name
);
