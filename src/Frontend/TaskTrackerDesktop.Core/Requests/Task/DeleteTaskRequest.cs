using System;

namespace TaskTrackerDesktop.Core.Requests.Task;

public sealed record DeleteTaskRequest(
    Guid Id    
);
