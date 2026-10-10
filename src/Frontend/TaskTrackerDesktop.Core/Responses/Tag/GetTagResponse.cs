using System;

namespace TaskTrackerDesktop.Core.Responses.Tag;

public sealed record GetTagResponse(
    Guid Id,
    string Name
);
