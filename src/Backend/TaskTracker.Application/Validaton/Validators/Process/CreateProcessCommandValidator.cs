using TaskTracker.Application.Commands.Process.CreateProcess;

namespace TaskTracker.Application.Validaton.Validators.Process;

public sealed class CreateProcessCommandValidator : ValidatorBase<CreateProcessCommand>
{
    public CreateProcessCommandValidator()
    {
        ValidateId(x => x.AdminId, required: true);
        ValidateDescription(x => x.Description, required: true);
        ValidateName(x => x.Name, required: true);
        ValidateBoolean(x => x.IsActive, required: true);
    }
}
