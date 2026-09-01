using TaskTracker.Application.Commands.Remark.CreateRemark;

namespace TaskTracker.Application.Validaton.Validators.Remark;

public sealed class CreateRemarkCommandValidator : ValidatorBase<CreateRemarkCommand>
{
    public CreateRemarkCommandValidator()
    {
        ValidateText(x => x.Text, required: true);
        ValidateId(x => x.TaskId, required: true);
        ValidateId(x => x.UserId, required: true);
    }
}
