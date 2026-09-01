using MediatR;

namespace TaskTracker.Application.Queries.Process.Get;

public sealed record GetProcessQuery(
    Guid Id
) : IRequest<GetProcessQueryResult>;
