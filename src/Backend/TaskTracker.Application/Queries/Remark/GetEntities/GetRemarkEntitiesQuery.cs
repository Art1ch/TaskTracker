using MediatR;

namespace TaskTracker.Application.Queries.Remark.GetEntities;

public sealed record GetRemarkEntitiesQuery(
    int Page,
    int PageSize,
    Guid? TaskId,
    DateTime? From,
    DateTime? To,
    string? Text
) : IRequest<GetRemarkEntitiesQueryResult>;
