using MediatR;

namespace TaskTracker.Application.Queries.Remark.Get;

public sealed record GetRemarkQuery(
    Guid Id
) : IRequest<GetRemarkQueryResult>;
