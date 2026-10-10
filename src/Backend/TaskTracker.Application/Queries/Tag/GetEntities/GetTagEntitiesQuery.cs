using MediatR;

namespace TaskTracker.Application.Queries.Tag.GetEntities;

public sealed record GetTagEntitiesQuery(
    int Page,
    int PageSize,
    Guid? ProcessId,
    DateTime? From,
    DateTime? To,
    string? Name
) : IRequest<GetTagEntitiesQueryResult>;
