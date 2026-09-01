using TaskTracker.Application.Commands.Process.DeleteProcess;

namespace TaskTracker.Application.Validaton.Validators.Process;

public sealed class DeleteProcessCommandValidator : ValidatorBase<DeleteProcessCommand>
{
    public DeleteProcessCommandValidator()
    {
        ValidateId(x => x.Id, required: true);
    }
}
