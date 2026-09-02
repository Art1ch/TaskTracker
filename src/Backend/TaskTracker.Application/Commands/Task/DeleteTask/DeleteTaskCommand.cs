using MediatR;

namespace TaskTracker.Application.Commands.Task.DeleteTask;

public sealed record DeleteTaskCommand(
    Guid Id
) : IRequest<DeleteTaskCommandResult>;