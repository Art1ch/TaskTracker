using TaskTracker.Application.Commands.Remark.DeleteRemark;

namespace TaskTracker.Application.Validaton.Validators.Remark;

public sealed class DeleteRemarkCommandValidator : ValidatorBase<DeleteRemarkCommand>
{
    public DeleteRemarkCommandValidator()
    {
        ValidateId(x => x.Id, required: true);
    }
}
