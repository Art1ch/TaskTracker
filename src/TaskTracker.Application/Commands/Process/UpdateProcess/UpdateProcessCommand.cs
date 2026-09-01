using MediatR;

namespace TaskTracker.Application.Commands.Process.UpdateProcess;

public sealed record UpdateProcessCommand(
    Guid Id,
    string? Name,
    string? Description,
    bool? IsActive
) : IRequest<UpdateProcessCommandResult>;
