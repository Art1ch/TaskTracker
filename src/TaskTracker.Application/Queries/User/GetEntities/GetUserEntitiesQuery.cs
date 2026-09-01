using MediatR;
using TaskTracker.Core.Enums;

namespace TaskTracker.Application.Queries.User.GetEntities;

public sealed record GetUserEntitiesQuery(
    int Page,
    int PageSize,
    DateTime? From,
    DateTime? To,
    string? FirstName,
    string? LastName,
    UserRole? Role
) : IRequest<GetUserEntitiesQueryResult>;
