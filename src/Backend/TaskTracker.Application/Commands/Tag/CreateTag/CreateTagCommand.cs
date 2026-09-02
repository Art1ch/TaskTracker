using MediatR;

namespace TaskTracker.Application.Commands.Tag.CreateTag;

public sealed record CreateTagCommand(
    Guid ProcessId,
    string Name
) : IRequest<CreateTagCommandResult>;