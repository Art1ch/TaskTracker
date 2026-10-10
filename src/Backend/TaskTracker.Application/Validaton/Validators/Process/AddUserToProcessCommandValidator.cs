using TaskTracker.Application.Commands.Process.AddUserToProcess;

namespace TaskTracker.Application.Validaton.Validators.Process;

public sealed class AddUserToProcessCommandValidator : ValidatorBase<AddUserToProcessCommand>
{
    public AddUserToProcessCommandValidator()
    {
        ValidateId(x => x.ProcessId, required: true);
        ValidateId(x => x.UserId, required: true);
        ValidateId(x => x.AdminId, required: true);
    }
}
