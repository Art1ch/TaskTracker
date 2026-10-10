using MediatR;

namespace TaskTracker.Application.Commands.Auth.Logout;

public sealed record LogoutCommand(
    string RefreshToken
) : IRequest<LogoutCommandResult>;
