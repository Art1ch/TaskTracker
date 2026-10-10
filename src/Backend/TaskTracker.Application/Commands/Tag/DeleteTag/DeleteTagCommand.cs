using MediatR;

namespace TaskTracker.Application.Commands.Tag.DeleteTag;

public sealed record DeleteTagCommand(
    Guid Id
) : IRequest<DeleteTagCommandResult>;