using FluentValidation;
using TaskTracker.Application.Commands.Auth.Refresh;

namespace TaskTracker.Application.Validaton.Validators.Auth;

public sealed class RefreshCommandValidator : ValidatorBase<RefreshCommand>
{
    public RefreshCommandValidator()
    {
        RuleFor(x => x.RefreshToken)
            .NotEmpty()
            .NotNull();
    }
}
