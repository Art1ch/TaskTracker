using TaskTracker.Application.Commands.Task.CreateTask;
using TaskTracker.Core.Enums;

namespace TaskTracker.Application.Validaton.Validators.Task;

public sealed class CreateTaskCommandValidator : ValidatorBase<CreateTaskCommand>
{
    public CreateTaskCommandValidator()
    {
        ValidateTitle(x => x.Title, required: true);
        ValidateEnum<TaskState>(x => x.State, required: true);
        ValidateDeadline(x => x.Deadline);
        ValidateId(x => x.ProcessId, required: true);
        ValidateId(x => x.CreatedById, required: true);
        ValidateId(x => x.AssignedToId, required: true);
    }
}
