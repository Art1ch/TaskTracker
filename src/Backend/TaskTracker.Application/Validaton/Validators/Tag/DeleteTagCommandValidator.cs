using TaskTracker.Application.Commands.Tag.DeleteTag;

namespace TaskTracker.Application.Validaton.Validators.Tag;

public sealed class DeleteTagCommandValidator : ValidatorBase<DeleteTagCommand>
{
    public DeleteTagCommandValidator()
    {
        ValidateId(x => x.Id, required: true);
    }
}
