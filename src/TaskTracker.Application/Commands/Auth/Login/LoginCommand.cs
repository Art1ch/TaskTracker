using MediatR;

namespace TaskTracker.Application.Commands.Auth.Login;

public sealed record LoginCommand(
    string Email,
    string Password
) : IRequest<LoginCommandResult>;