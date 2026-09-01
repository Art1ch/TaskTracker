using TaskTracker.Application.Commands.Auth.Login;

namespace TaskTracker.Application.Validaton.Validators.Auth;

public sealed class LoginCommandValidator : ValidatorBase<LoginCommand>
{
    public LoginCommandValidator()
    {
        ValidateEmail(x => x.Email, required: true);
        ValidatePassword(x => x.Password, required: true);
    }
}
