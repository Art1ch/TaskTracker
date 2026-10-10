using TaskTracker.Application.Commands.Task.DeleteTask;
using TaskTracker.Application.Requests.Task;

namespace TaskTracker.Application.Validaton.Validators.Task;

public sealed class DeleteTaskCommandValidator : ValidatorBase<DeleteTaskCommand>
{
    public DeleteTaskCommandValidator()
    {
        ValidateId(x => x.Id, required: true);
    }
}
