using MediatR;

namespace TaskTracker.Application.Queries.Task.Get;

public sealed record GetTaskQuery(
    Guid Id
) : IRequest<GetTaskQueryResult>;
