using MediatR;

namespace TaskTracker.Application.Commands.Auth.Refresh;

public sealed record RefreshCommand(
    string RefreshToken
) : IRequest<RefreshCommandResult>;
