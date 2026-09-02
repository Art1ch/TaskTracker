using MediatR;
using TaskTracker.Core.Enums;

namespace TaskTracker.Application.Queries.Task.GetEntities;

public sealed record GetTaskEntitiesQuery(
    int Page,
    int PageSize,
    string? Title,
    string? Description,
    TaskState? State,
    DateTime? Deadline,
    Guid? ProcessId,
    Guid? CreatedById,
    Guid? AssignedToId,
    DateTime? From,
    DateTime? To
) : IRequest<GetTaskEntitiesQueryResult>;
