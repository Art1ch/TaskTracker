using MediatR;
using TaskTracker.Core.Enums;

namespace TaskTracker.Application.Commands.Task.UpdateTask;

public sealed record UpdateTaskCommand(
    Guid Id,
    string Title,
    string Description,
    TaskState TaskState,
    Guid AssignedToId,
    DateTime? Deadline
) : IRequest<UpdateTaskCommandResult>;