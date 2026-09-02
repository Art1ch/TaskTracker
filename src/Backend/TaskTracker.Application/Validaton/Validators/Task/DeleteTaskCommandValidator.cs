using TaskTracker.Application.Requests.Task;

namespace TaskTracker.Application.Validaton.Validators.Task;

public sealed class DeleteTaskCommandValidator : ValidatorBase<DeleteTaskRequest>
{
    public DeleteTaskCommandValidator()
    {
        ValidateId(x => x.Id, required: true);
    }
}
