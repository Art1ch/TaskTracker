using MediatR;

namespace TaskTracker.Application.Commands.Auth.Register;

public sealed record RegisterCommand(
    string Email,
    string FirstName,
    string LastName,
    string Password
) : IRequest<RegisterCommandResult>;
