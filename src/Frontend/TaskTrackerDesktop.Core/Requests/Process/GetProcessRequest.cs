using System;

namespace TaskTrackerDesktop.Core.Requests.Process;

public sealed record GetProcessRequest(
    Guid Id  
);