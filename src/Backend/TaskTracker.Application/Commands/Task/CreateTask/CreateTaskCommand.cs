using MediatR;
using TaskTracker.Core.Enums;

namespace TaskTracker.Application.Commands.Task.CreateTask;

public sealed record CreateTaskCommand(
    Guid ProcessId,
    Guid CreatedById,
    Guid AssignedToId,
    string Title,
    string Description,
    TaskState State,
    DateTime? Deadline
) : IRequest<CreateTaskCommandResult>;