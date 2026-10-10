using MediatR;

namespace TaskTracker.Application.Commands.Process.DeleteProcess;

public sealed record DeleteProcessCommand(
    Guid Id
) : IRequest<DeleteProcessCommandResult>;