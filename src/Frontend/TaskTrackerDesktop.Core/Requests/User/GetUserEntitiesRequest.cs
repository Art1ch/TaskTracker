using TaskTrackerDesktop.Core.Requests.Base;
using TaskTrackerDesktop.Core.Enums;
using System;

namespace TaskTrackerDesktop.Core.Requests.User;

public sealed record GetUserEntitiesRequest(
    int Page,
    int PageSize,
    DateTime? From,
    DateTime? To,
    UserRole? UserRole,
    string? FirstName,
    string? LastName
) : GetEntitiesRequestBase(Page, PageSize, From, To);
