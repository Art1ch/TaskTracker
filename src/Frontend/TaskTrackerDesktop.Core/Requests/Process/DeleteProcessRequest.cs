using System;

namespace TaskTrackerDesktop.Core.Requests.Process;

public sealed record DeleteProcessRequest(
    Guid Id    
);
