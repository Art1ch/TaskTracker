using MediatR;

namespace TaskTracker.Application.Commands.Process.CreateProcess;

public sealed record CreateProcessCommand(
    Guid AdminId,
    string Name,
    string Description,
    bool IsActive
) : IRequest<CreateProcessCommandResult>;