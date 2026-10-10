using System;

namespace TaskTrackerDesktop.Core.Requests.User;

public sealed record GetUserRequest(
    Guid Id    
);
