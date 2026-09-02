using MediatR;

namespace TaskTracker.Application.Commands.Tag.UpdateTag;

public sealed record UpdateTagCommand(
    Guid Id,
    string Name
) : IRequest<UpdateTagCommandResult>;
