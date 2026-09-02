using MediatR;

namespace TaskTracker.Application.Queries.Process.GetEntities;

public sealed record GetProcessEntitiesQuery(
    int Page,
    int PageSize,
    DateTime? From,
    DateTime? To,
    string? Name,
    string? Description,
    bool? IsActive
) : IRequest<GetProcessEntitiesQueryResult>;