using System;

namespace TaskTrackerDesktop.Core.Requests.Tag;

public sealed record DeleteTagRequest(
    Guid Id
);
