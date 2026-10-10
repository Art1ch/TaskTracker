using System;

namespace TaskTrackerDesktop.Core.Requests.Task;

public sealed record GetTaskRequest(
    Guid Id    
);
