using MediatR;

namespace TaskTracker.Application.Queries.Tag.Get;

public sealed record GetTagQuery(
    Guid Id
) : IRequest<GetTagQueryResult>;