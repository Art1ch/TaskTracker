using TaskTracker.Application.Commands.Auth.Register;

namespace TaskTracker.Application.Validaton.Validators.Auth;

public sealed class RegisterCommandValidator : ValidatorBase<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        ValidateEmail(x => x.Email, required: true);
        ValidateFirstName(x => x.FirstName, required: true);
        ValidateLastName(x => x.LastName, required: true);
        ValidatePassword(x => x.Password, required: true);
    }
}