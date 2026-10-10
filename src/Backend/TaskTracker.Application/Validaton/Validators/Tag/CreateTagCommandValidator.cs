using TaskTracker.Application.Commands.Tag.CreateTag;

namespace TaskTracker.Application.Validaton.Validators.Tag;

public sealed class CreateTagCommandValidator : ValidatorBase<CreateTagCommand>
{
    public CreateTagCommandValidator()
    {
        ValidateId(x => x.ProcessId, required: true);
        ValidateText(x => x.Name, required: true);
    }
}
