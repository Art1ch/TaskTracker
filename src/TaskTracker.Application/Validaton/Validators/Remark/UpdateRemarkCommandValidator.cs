using FluentValidation;
using TaskTracker.Application.Commands.Remark.UpdateRemark;
using TaskTracker.Application.Validaton.ErrorCodes;

namespace TaskTracker.Application.Validaton.Validators.Remark;

public sealed class UpdateRemarkCommandValidator : ValidatorBase<UpdateRemarkCommand>
{
    public UpdateRemarkCommandValidator()
    {
        ValidateId(x => x.Id, required: true);
        ValidateText(x => x.Text);
        ValidateId(x => x.TaskId);
        ValidateId(x => x.UserId);

        RuleFor(x => x)
            .Must(x =>
                x.Text != null ||
                x.TaskId != null ||
                x.UserId != null
            )
            .WithErrorCode(ValidationErrorCodes.NoFieldsToUpdate);
    }
}
