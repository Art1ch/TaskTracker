using System;

namespace TaskTrackerDesktop.Core.Requests.Tag;

public sealed record UpdateTagRequest(
    Guid Id,
    string Name
);
