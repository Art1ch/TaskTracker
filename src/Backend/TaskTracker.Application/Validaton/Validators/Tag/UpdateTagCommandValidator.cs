using TaskTracker.Application.Commands.Tag.UpdateTag;

namespace TaskTracker.Application.Validaton.Validators.Tag;

public sealed class UpdateTagCommandValidator : ValidatorBase<UpdateTagCommand>
{
    public UpdateTagCommandValidator()
    {
        ValidateId(x => x.Id, required: true);
        ValidateText(x => x.Name, required: true);
    }
}
