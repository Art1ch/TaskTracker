using System;

namespace TaskTrackerDesktop.Core.Requests.Tag;

public sealed record GetTagRequest(
    Guid Id
);
