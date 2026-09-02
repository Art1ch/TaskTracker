using TaskTracker.Application.Commands.Task.UpdateTask;
using TaskTracker.Core.Enums;

namespace TaskTracker.Application.Validaton.Validators.Task;

public sealed class UpdateTaskCommandValidator : ValidatorBase<UpdateTaskCommand>
{
    public UpdateTaskCommandValidator()
    {
        ValidateId(x => x.Id, required: true);
        ValidateEnum<TaskState>(x => x.State);
        ValidateDeadline(x => x.Deadline);
        ValidateId(x => x.AssignedToId);
    }
}
