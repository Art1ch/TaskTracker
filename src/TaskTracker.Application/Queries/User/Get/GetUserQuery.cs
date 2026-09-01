using MediatR;

namespace TaskTracker.Application.Queries.User.Get;

public sealed record GetUserQuery(
    Guid Id
) : IRequest<GetUserQueryResult>;
