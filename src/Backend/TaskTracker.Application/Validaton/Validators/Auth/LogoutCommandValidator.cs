using FluentValidation;
using TaskTracker.Application.Commands.Auth.Logout;

namespace TaskTracker.Application.Validaton.Validators.Auth;

public sealed class LogoutCommandValidator : ValidatorBase<LogoutCommand>
{
    public LogoutCommandValidator()
    {
        RuleFor(x => x.RefreshToken)
            .NotEmpty()
            .NotNull();
    }
}