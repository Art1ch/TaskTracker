using System;

namespace TaskTrackerDesktop.Core.Responses.Tag;

public sealed record GetTagEntitiesResponseItem(
    Guid Id,
    string Name
);