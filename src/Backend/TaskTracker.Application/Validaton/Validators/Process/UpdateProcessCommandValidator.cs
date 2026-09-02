using FluentValidation;
using TaskTracker.Application.Commands.Process.UpdateProcess;
using TaskTracker.Application.Validaton.ErrorCodes;

namespace TaskTracker.Application.Validaton.Validators.Process;

public sealed class UpdateProcessCommandValidator : ValidatorBase<UpdateProcessCommand>
{
    public UpdateProcessCommandValidator()
    {
        ValidateId(x => x.Id, required: true);
        ValidateDescription(x => x.Description);
        ValidateName(x => x.Name);
        ValidateBoolean(x => x.IsActive);

        RuleFor(x => x)
            .Must(x =>
                x.Description != null ||
                x.Name != null ||
                x.IsActive != null
            )
            .WithErrorCode(ValidationErrorCodes.NoFieldsToUpdate);
    }
}
