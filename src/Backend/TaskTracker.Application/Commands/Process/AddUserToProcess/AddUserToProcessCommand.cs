using MediatR;

namespace TaskTracker.Application.Commands.Process.AddUserToProcess;

public sealed record AddUserToProcessCommand(
    Guid UserId,
    Guid ProcessId,
    Guid AdminId
) : IRequest<AddUserToProcessCommandResult>;
